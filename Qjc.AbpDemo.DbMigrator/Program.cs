using Microsoft.Extensions.DependencyInjection;
using Qjc.AbpDemo.Application.Data;
using Qjc.AbpDemo.DbMigrator;
using Volo.Abp;

using var application = await AbpApplicationFactory.CreateAsync<AbpDemoDbMigratorModule>(options => 
{
    options.UseAutofac();
});
await application.InitializeAsync();
Console.WriteLine("ABP has been started...");
Console.WriteLine("开始数据库迁移");
try
{
    var abpDemoDbSchemaMigrator = application.ServiceProvider.GetRequiredService<AbpDemoDbSchemaMigrator>();
    var abpDemoDataSeederContributor = application.ServiceProvider.GetRequiredService<AbpDemoDataSeederContributor>();
    await abpDemoDbSchemaMigrator.MigrateAsync();
    await abpDemoDataSeederContributor.SeedAsync(new Volo.Abp.Data.DataSeedContext());
    Console.WriteLine("数据库迁移成功");
}
catch (Exception ex)
{
    Console.WriteLine("数据库迁移失败: " + ex.Message);
}
await application.ShutdownAsync();
