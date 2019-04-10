using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveLarn.Core.Configuration;
using LiveLarn.Service.Identity.DAL;
using LiveLarn.Service.Identity.Models;
using LiveLarn.Service.Identity.Models.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LiveLarn.Service.Identity
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
            services.AddDbContext<ApplicationIdentityDBContext>(
              options => options.UseSqlServer(AppConfiguration.Instance.Configuration.GetConnectionString("ArthurServiceSecurityDB")));

            services.AddIdentity<ApplicationUser, IdentityRole<string>>()
                .AddEntityFrameworkStores<ApplicationIdentityDBContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddIdentityServer()
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddTestUsers(Config.GetUsers())
                .AddAspNetIdentity<ApplicationUser>()
                .AddInMemoryPersistedGrants()
                .AddDeveloperSigningCredential();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Koton.ArthurService.Security", Version = "v1" });
            });
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
            app.UseMvc();
        }
    }
}
