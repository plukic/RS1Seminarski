using Microsoft.AspNetCore.Builder;
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
using ConstructionDiary.BR.EquipmentManagement.Implementation;
using ConstructionDiary.BR.EquipmentManagement.Interfaces;
using ConstructionDiary.BR.MaterialsManagement.Implementation;
using ConstructionDiary.BR.MaterialsManagement.Interfaces;
using DataLayer.Models;
using ConstructionDiary.BR.UserManagment.Interfaces;
using ConstructionDiary.BR.WorkersManagement.Implementation;
using React.AspNet;
using ConstructionDiary.BR.WorkSheetManagement.Interfaces;
using ConstructionDiary.BR.WorkSheetManagement.Implementation;
using ConstructionDiary.BR.ControlEntity.Implementation;
using ConstructionDiary.BR.ControlEntity.Intefaces;

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
        public IServiceProvider ConfigureServices(IServiceCollection services)
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
                options.AccessDeniedPath = "/Error/UnauthorizedError"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserDA, UserDA>();
            services.AddTransient<IRoleDA, RoleDA>();
            services.AddTransient<IUserManagment, UserManagment>();
            services.AddTransient<IConstructionSitesService, ConstructionSitesService>();
            services.AddTransient<IDocumentsService, DocumentsService>();
            services.AddTransient<IEquipmentService, EquipmentService>();
            services.AddTransient<IMaterialsService, MaterialsService>();
            services.AddTransient<IControlEntityService, ControlEntityService>();
            services.AddTransient<IWorkSheetService, WorkSheetService>();
            services.AddTransient<IWorkersService, WorkersService>();


            services.AddReact();

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddLogging();
            return services.BuildServiceProvider();
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

            app.UseReact(config =>
            {

            });
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
