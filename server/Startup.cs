using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rap.Api.Converters;
using Rap.Data;
using Rap.Data.Initializer;
using Rap.Services.Implementations;
using Rap.Services.Interfaces;
using System;
using System.Linq;
using System.Reflection;

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
            ConfigureAutomapper(services);

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                }); ;
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
            services.AddDbContext<ApplicationDbContext>(o => 
                o.UseSqlServer(@"Server=.;Database=rap;Trusted_Connection=True;",
                    opts => opts.EnableRetryOnFailure(3)));
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
            services.AddTransient<IFlightService, FlightService>();
        }

        private void ConfigureAutomapper(IServiceCollection services)
        {
            Assembly thisAssembly = AppDomain.CurrentDomain.GetAssemblies().Single(a => a.GetName().Name == "Rap.Api");
            AssemblyName[] assemblies = thisAssembly.GetReferencedAssemblies();
            AssemblyName name = assemblies.Single(a => a.Name == "Rap.Models");
            Assembly modelsAssembly = Assembly.Load(name);

            services.AddAutoMapper(modelsAssembly);
        }
    }
}
