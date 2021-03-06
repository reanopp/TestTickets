﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTickets2.Data;
using TestTickets2.Models;

namespace TestTickets2
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
            services.AddMvc();
                //.AddSessionStateTempDataProvider(); //required for session variables

            services.AddDbContext<TestTicketContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TestTicketContext")));

            services.AddDistributedMemoryCache(); //required for session variables
            services.AddSession(); //required for session variables
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                //.AddEntityFrameworkStores<IdentityContext, Guid>()
                //.AddDefaultTokenProviders();

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<TestTicketContext>().AddDefaultTokenProviders();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            //must go before UseMvc
            app.UseSession(); //required for session variables

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=TicketListView}/{action=Index}/{id?}");
            });
        }
    }
}
