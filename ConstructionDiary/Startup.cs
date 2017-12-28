﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConstructionDiary.DAL;
using Microsoft.AspNetCore.Identity;
using System;
using ConstructionDiary.BR.UserManagment.Implementation;
using ConstructionDiary.BR.UserManagment;
using Microsoft.EntityFrameworkCore;
using ConstructionDiary.BR.ConstructionSites.Interfaces;
using ConstructionDiary.BR.ConstructionSites.Implementation;
using ConstructionDiary.BR.Documents.Interfaces;
using ConstructionDiary.BR.Documents.Implementation;
using DataLayer.Models;
using ConstructionDiary.BR.UserManagment.Interfaces;

namespace ConstructionDiary
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

            services.AddDbContext<ConstructionCompanyContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("local")));
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 4;
            })
                .AddEntityFrameworkStores<ConstructionCompanyContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Login/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Home/Error"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserDA, UserDA>();
            services.AddTransient<IRoleDA, RoleDA>();
            services.AddTransient<IUserManagment, UserManagment>();
            services.AddTransient<IConstructionSitesService, ConstructionSitesService>();
            services.AddTransient<IDocumentsService, DocumentsService>();

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddLogging();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            AuthAppBuilderExtensions.UseAuthentication(app);
            app.UseMvcWithDefaultRoute();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
