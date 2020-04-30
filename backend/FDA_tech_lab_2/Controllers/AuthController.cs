using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FDA_tech_lab_2.Models;


namespace FDA_tech_lab_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("token")]
        public string GetToken()
        {
            return Authorization.GenerateToken();
        }
        [HttpGet("token/secret")]
        public string GetAdminToken()
        {
            return Authorization.GenerateToken(true);
        }
    }
}