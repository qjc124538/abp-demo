using Asp.Versioning;
using Asp.Versioning.ApplicationModels;
using Microsoft.OpenApi.Models;
using Qjc.AbpDemo.Application;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace Qjc.AbpDemo.Web
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(AbpSwashbuckleModule),
        typeof(AbpDemoApplicationModule)
        )]
    public class AbpDemoWebModule: AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            #region 自动API
            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(AbpDemoApplicationModule).Assembly);
            });
            #endregion
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            #region swagger
            context.Services.AddAbpSwaggerGen(options => 
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "QjcAbpDemo API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                options.HideAbpEndpoints();
            });
            #endregion
            #region CORS
            context.Services.AddCors(options =>
            {
                options.AddPolicy("Default", builder =>
                {
                    builder.WithOrigins(configuration["App:CorsOrigins"].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(o => o.RemovePostFix("/")).ToArray());
                });
            });
            #endregion
            context.Services.AddSameSiteCookiePolicy();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseCookiePolicy();
            app.UseStaticFiles();
            #region swagger
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "QjcAbpDemo API");
            });
            #endregion
            app.UseRouting();
            #region CORS
            app.UseCors("Default");
            #endregion
            app.UseConfiguredEndpoints();
        }
    }
}
