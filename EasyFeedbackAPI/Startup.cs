using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFeedbackAPI.data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            services.AddControllers();

            //Añadimos el EasyFeedbackContext y lo apuntamos a la connectionString.
            services.AddDbContext<EasyFeedbackContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("RDSPRE")));

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

            //Permitimos servir Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "help/swagger/{documentname}/swagger.json";
            });
            //Permitimos servir Swagger-ui(HTML, etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/help/swagger/v0/swagger.json", name: "EasyFeedBack V0");
                c.RoutePrefix = "help/swagger";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
