using Qjc.AbpDemo.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();
await builder.AddApplicationAsync<AbpDemoWebModule>();
var app = builder.Build();
await app.InitializeApplicationAsync();
await app.RunAsync();