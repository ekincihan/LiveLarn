using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveLarn.Service.Company.Configuration
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
          this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                  description.GroupName,
                    new Info()
                    {
                        Title = $"LiveLarn.Service.Company {description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                    });
            }
        }
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // format the version as "'v'major[.minor][-status]"
        services.AddMvc(options => options.EnableEndpointRouting = false);
        services.AddApiVersioning();
        services.AddOData().EnableApiVersioning();
        services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen();
    }

    public void Configure(
        IApplicationBuilder app,
        VersionedODataModelBuilder modelBuilder,
        IApiVersionDescriptionProvider provider)
    {
        var models = modelBuilder.GetEdmModels();
        app.UseMvc(routes => routes.MapVersionedODataRoutes("odata", null, models));
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });
    }
}
