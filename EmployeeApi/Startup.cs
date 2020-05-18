using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBusinesLayer.Interfaces;
using EmployeeBusinesLayer.services;
using EmployeeRL.Interfaces;
using EmployeeRL.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EmployeeApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

         public void ConfigureServices(IServiceCollection services)
        {
            //set version of application
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //it can create single instance and give simple access globaly
            services.AddSingleton<IConfiguration>(Configuration);
            //a new instance is provided every time a service instance is requested
            services.AddTransient<InterfaceEmployeeRL, EmployeeRepositoryLayer>();
            services.AddTransient<InterfaceEmployeeBusinessLayer, EmployeeBusinessLayer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
