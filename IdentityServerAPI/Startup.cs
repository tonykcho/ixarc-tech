using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerCore.Clients;
using IdentityServerCore.Resources;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServerAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigureDatabase(services);

            ConfigureCookies(services);

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiScopes(IdentityServerApiScope.DefaultServerApiScopes)
                .AddInMemoryIdentityResources(IdentityServerResource.DefaultResources)
                .AddInMemoryApiResources(IdentityServerApiResource.DefaultApiResources)
                .AddInMemoryClients(IdentityServerClient.DefaultClients);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseIdentityServer();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            context.Database.Migrate();
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
        }

        private void ConfigureCookies(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie();
        }
    }
}
