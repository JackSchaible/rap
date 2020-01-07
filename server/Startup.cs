using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rap.Data;
using Rap.Data.Initializer;

namespace RapServer
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDb(services);
            ConfigureCors(services);
            ConfigureBllServices(services);

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context, IDbInitializer initializer)
        {
            if (_env.EnvironmentName == "Development")
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseCors(b => b.WithOrigins("http://rap.jackschaible.ca/"));
                app.UseHsts();
            }

            app.UseCors("AllowOrigin");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            context.Database.EnsureCreated();
            initializer.Initialize();
        }

        private void ConfigureDb(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.Configure<InitializerOptions>(o => o.RootPath = _env.ContentRootPath);
            services.AddScoped<IDbInitializer, DbInitializer>();
        }

        private void ConfigureCors(IServiceCollection services)
        {
            string domain = _env.EnvironmentName == "Development" ? "https://localhost:4200" : "http://dm.jackschaible.ca";

            services.AddCors(o =>
                o.AddPolicy("AllowOrigin",
                    b => b.WithOrigins(domain)
                        .AllowAnyHeader()
                        .AllowAnyMethod()));
        }

        private void ConfigureBllServices(IServiceCollection services)
        {
            //services.AddTransient<ISpellService, SpellService>();
        }

    }
}
