using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CR.CricketerRanking
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Login}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "Login",
                template: "{controller}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional });

                routes.MapRoute(
                name: "Registration",
                template: "{controller}",
                defaults: new { controller = "Registration", action = "Registration", id = UrlParameter.Optional });

                routes.MapRoute(
                name: "UserList",
                template: "{controller}",
                defaults: new { controller = "UserList", action = "UserList", id = UrlParameter.Optional });

                routes.MapRoute(
                name: "CricktersPoll",
                template: "{controller}",
                defaults: new { controller = "CricktersPoll", action = "CricktersPoll", id = UrlParameter.Optional });

                routes.MapRoute(
                name: "CricktersPollWithoutLogin",
                template: "{controller}",
                defaults: new { controller = "CricktersPollWithoutLogin", action = "CricktersPollWithoutLogin", id = UrlParameter.Optional });
            });
        }
    }
}
