using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClient
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
            services.AddControllersWithViews();

            services.AddAuthentication(config => {
                config.DefaultScheme = "MvcCookie";
                config.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("MvcCookie")
                .AddOpenIdConnect("oidc", config => {
                    config.ClientId = "real_user_client";
                    config.ClientSecret = "secret";
                    config.SaveTokens = true;
                    config.Authority = "https://localhost:5001/";

                    config.ResponseType = "code";
                    config.RequireHttpsMetadata = false;
                });

            services.AddHttpClient().AddHeaderPropagation();

            services.AddHeaderPropagation(options =>
            {
                options.Headers.Add(CookieAuthenticationDefaults.AuthenticationScheme);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseHeaderPropagation();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
