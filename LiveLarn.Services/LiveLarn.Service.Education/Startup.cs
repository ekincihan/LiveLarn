﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using LiveLarn.Core.Configuration;
using LiveLarn.Core.DataAccess;
using LiveLarn.Core.DataAccess.EntityFramework;
using LiveLarn.Service.Education.DataAccess;
using LiveLarn.Service.Education.DataAccess.Abstract;
using LiveLarn.Service.Education.Models.Entity;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;

namespace LiveLarn.Service.Education
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
            services.AddOData();
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });

            services.AddAuthentication(
            IdentityServerAuthenticationDefaults.AuthenticationScheme)
               .AddIdentityServerAuthentication(options =>
               {
                   // base-address of your identityserver
                   options.Authority = AppConfiguration.Instance.Configuration.GetValue<string>("Auth0:Domain");
                   // name of the API resource
                   options.ApiName = AppConfiguration.Instance.Configuration.GetValue<string>("Auth0:ApiResource");
                   options.RequireHttpsMetadata = false; // only for development
               });

            services.Configure<Settings>(
            options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoDb:Database").Value;
            });
            services.AddTransient<IEducationDbContext, EducationDbContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "LiveLarn.Service.Education", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>()
                {
                  { "Bearer", new string[]{ } }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();
            var builder = new ODataConventionModelBuilder(app.ApplicationServices);

            //builder.EntitySet<Category>("Categories");
            //builder.EntitySet<Subject>("Subject");
            //builder.EntitySet<Models.Entity.Type>("Types");
            //builder.EntitySet<ClassLevel>("ClassLevels");

            //app.UseMvc(routeBuilder =>
            //{
            //    routeBuilder.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
            //    routeBuilder.Expand(Microsoft.AspNet.OData.Query.QueryOptionSetting.Allowed).Select().Count().OrderBy().Filter().MaxTop(null);
            //    routeBuilder.EnableDependencyInjection();
            //});
            app.UseSwagger();
            app.UseMvcWithDefaultRoute();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiveLarn.Service.Education");
            });

        }
    }
}
