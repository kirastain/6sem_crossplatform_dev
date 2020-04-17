using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FDA_tech_lab_2.Models
{
    internal class Authorization
    {
        public static string Issuer => "FDA_lab_2";
        public static string Audience => "LNGwannaknows";
        public static int LifetimeInYears => 2;
        public static SecurityKey SigningKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes("NothingIsTrueEverythingIsPermitted"));
    }
}
