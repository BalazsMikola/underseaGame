using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Identity
{
    public class JwtTokens
    {
        public const string Issuer = "MVS";
        public const string Audience = "ApiUser";
        public const string Key = "0123456789012345678901234567890123456789";

        public const string AuthSchemes = "Identity.Application" + "," + JwtBearerDefaults.AuthenticationScheme;
    }
}
