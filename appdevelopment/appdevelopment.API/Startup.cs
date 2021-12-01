using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore.Proxies;

namespace appdevelopment.API
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
            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<skpContext>(opt =>
            opt.UseMySql(Configuration.GetConnectionString("appdev"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.25-mariadb"))
            .EnableSensitiveDataLogging()
            .UseLazyLoadingProxies());
            //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
