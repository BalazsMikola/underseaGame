﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            services.AddDefaultIdentity<AppUser>().AddEntityFrameworkStores<ApplicationDbContext>();
                //.AddDefaultTokenProviders();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
