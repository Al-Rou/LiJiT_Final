using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LiJiT.API.Configuration;
using LiJiT.API.Models;
using LiJiT.DependencyConfig;
using LiJiT.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using static LiJiT.API.Configuration.RequestResponseLoggingMiddleware;

namespace LiJiT.API
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
            ConfigureServices configureServices = new ConfigureServices(services);
            services.AddDbContext<LiJiTDbContext>(options => options.UseSqlServer(

             //Configuration["ConnectionStrings:DefaultConnection"], //MyDbConnection
             Configuration["ConnectionStrings:MyDbConnection"],

             optionsBuilder => optionsBuilder.MigrationsAssembly("LiJiT.API")), ServiceLifetime.Singleton);

            services.AddCors(option =>
            {
                option.AddPolicy("CorsePolicy", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
                //.AllowCredentials()
                // SetIsOriginAllowed((host) => true).AllowCredentials()
                );
            });
            services.AddControllers();
           

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwt =>
                {
                    var key = Encoding.ASCII.GetBytes(Configuration["JwtSettings:Secret"]);

                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
                        IssuerSigningKey = new SymmetricSecurityKey(key), // Add the secret key to our Jwt encryption
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
                });
            services.AddAutoMapper(typeof(Startup));
            JwtSettings.Secret = Configuration["JwtSettings:Secret"];
            JwtSettings.TokenLifetimeMinutes= int.Parse(Configuration["JwtSettings:TokenLifetimeMinutes"]);
            JwtSettings.UserName= Configuration["JwtSettings:UserName"];
            JwtSettings.Password = Configuration["JwtSettings:Password"];
            LiJiT.Utility.Constants.LoginUserId = Configuration["JwtSettings:UserName"];

       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsePolicy");
            app.UseHttpsRedirection();
            void RequestResponseHandler(RequestProfilerModel requestProfilerModel)
            {
                Debug.Print(requestProfilerModel.Request);
                Debug.Print(Environment.NewLine);
                Debug.Print(requestProfilerModel.Response);
            }
            app.UseMiddleware<RequestResponseLoggingMiddleware>((Action<RequestProfilerModel>)RequestResponseHandler);
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
