using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EasyFeedbackAPI.data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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
using Newtonsoft.Json;

namespace EasyFeedbackAPI
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
            services.AddCors();
            services.AddControllers();

            //Añadimos el EasyFeedbackContext y lo apuntamos a la connectionString.
            services.AddDbContext<EasyFeedbackContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("RDSPRE")));

            var Region = Configuration["AWSCognito:Region"];
            var PoolId = Configuration["AWSCognito:PoolId"];
            var AppClientId = Configuration["AWSCognito:AppClientId"];
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKeyResolver = (s, securityToken, identifier, parameters) =>
                        {
                  // Get JsonWebKeySet from AWS
                  var json = new WebClient().DownloadString(parameters.ValidIssuer + "/.well-known/jwks.json");
                  // Serialize the result
                  return JsonConvert.DeserializeObject<JsonWebKeySet>(json).Keys;
                        },
                        ValidateIssuer = true,
                        ValidIssuer = $"https://cognito-idp.{Region}.amazonaws.com/{PoolId}",
                        ValidateLifetime = true,
                        LifetimeValidator = (before, expires, token, param) => expires > DateTime.UtcNow,
                        ValidateAudience = true,
                        ValidAudience = AppClientId,
                    };
                });
            //Anyadimos Swagger para controlar la pagina Help de la API.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "EasyFeedback", Version = "v0" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()
                );
            //Permitimos servir Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentname}/swagger.json";
            });
            //Permitimos servir Swagger-ui(HTML, etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v0/swagger.json", name: "EasyFeedBack V0");
                c.RoutePrefix = "swagger";
            });

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
