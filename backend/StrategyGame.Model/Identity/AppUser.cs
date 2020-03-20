using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Identity
{
    public class AppUser : IdentityUser
    {
        public string User { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
    }
}
