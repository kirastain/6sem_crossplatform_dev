// Unused usings removed
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FDA_tech_lab_2.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace FDA_tech_lab_2
{
    public class Startup
    {
        public static Database database = new Database();
        public static List<Person> Users { get; } = new List<Person>
        {
            new Person("user", "user", "user"),
            new Person("admin", "admin", "admin"),
        };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
               opt.UseInMemoryDatabase("Plants"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = Authorization.Issuer,

                    ValidateAudience = true,
                    ValidAudience = Authorization.Audience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = Authorization.SigningKey,

                    ValidateLifetime = true,
                };
            }
            );

            services.AddControllers();

            services.AddCors(options => options.AddDefaultPolicy(policy =>
                policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}