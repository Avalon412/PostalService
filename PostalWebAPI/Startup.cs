using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PostalService.DAL.Contracts;
using PostalService.DAL.Models;
using PostalService.DAL.Repositories;
using PostalService.Services.Contracts;
using PostalService.Services.Services;
using PostalWebAPI.Extentions;
using Serilog;
using System.IO;

namespace PostalWebAPI
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PostalWebAPI", Version = "v1" });

                var annotationsFile = Path.Combine(System.AppContext.BaseDirectory, "swagger.annotations.xml");
                //c.IncludeXmlComments(annotationsFile);
            });

            services.Configure<PostalDbSettings>(Configuration.GetSection(nameof(PostalDbSettings)));
            services.AddSingleton<IPostalDbSettings>(sp => sp.GetRequiredService<IOptions<PostalDbSettings>>().Value);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPackageService, PackageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PostalWebAPI v1"));
            }

            app.ConfigureExceptionHandler(Log.Logger);

            app.UseHeaderLogging(Log.Logger);

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
