using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StrategyGame.Bll.Interface;
using StrategyGame.Bll.Services;
using StrategyGame.Dal;
using StrategyGame.Model.DataManager;
using StrategyGame.Model.Entities;
using StrategyGame.Model.Identity;
using StrategyGame.Model.Repository;

namespace StrategyGame.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("underseaGame")));
            services.AddScoped<ICityDataRepository<City>, CityManager>();
            services.AddScoped<IBuildingAppService, BuildingAppService>();
            services.AddScoped<IUnitAppService, UnitAppService>();
            services.AddScoped<IUpgradeAppService, UpgradeAppService>();
            services.AddScoped<ICreateCityDbService, CreateCityDbService>();
            services.AddScoped<IGetCityDbService, GetCityDbService>();
            services.AddScoped<ICreateArmyDbService, CreateArmyDbService>();
            services.AddScoped<IBuyUnitsDbService, BuyUnitsDbService>();
            services.AddDefaultIdentity<AppUser>(config =>
            {
                config.Password.RequiredUniqueChars = 0;
                config.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = 403;
                    return Task.CompletedTask;
                };
            });

            services.AddAuthentication()
                    .AddCookie(config => config.SlidingExpiration = true)
                    .AddJwtBearer(config =>
                    {
                        config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                        {
                            ValidIssuer = JwtTokens.Issuer,
                            ValidAudience = JwtTokens.Audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokens.Key))
                        };
                    });
                    

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                );

            IdentityModelEventSource.ShowPII = true;
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
