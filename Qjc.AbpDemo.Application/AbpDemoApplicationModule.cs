using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Qjc.AbpDemo.Application.Contracts;
using Volo.Abp.Application;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Qjc.AbpDemo.Application
{
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    public class AbpDemoApplicationModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            string dataBaseType = configuration["DataBaseType"];
            context.Services.AddAbpDbContext<AbpDemoDbContext>(options => 
            {
                options.AddDefaultRepositories();
            });
            Configure<AbpDbConnectionOptions>(options =>
            {
                if (dataBaseType.Equals("SqlServer"))
                {
                    options.ConnectionStrings.Default = configuration["ConnectionStrings:SqlServer"];
                }
                else if (dataBaseType.Equals("Oracle"))
                {
                    options.ConnectionStrings.Default = configuration["ConnectionStrings:Oracle"];
                }
                else if (dataBaseType.Equals("Dm"))
                {
                    options.ConnectionStrings.Default = configuration["ConnectionStrings:Dm"];
                }
                else
                {
                    throw new Exception("数据库类型无效");
                }
            });
            Configure<AbpDbContextOptions>(options =>
            {
                if (dataBaseType.Equals("SqlServer"))
                {
                    options.Configure(configurationContext =>
                    {
                        configurationContext.UseSqlServer();
                    });
                }
                else if (dataBaseType.Equals("Oracle"))
                {
                    options.Configure(configurationContext =>
                    {
                        configurationContext.UseOracle();
                    });
                }
                else if (dataBaseType.Equals("Dm"))
                {
                    options.Configure(configurationContext =>
                    {
                        configurationContext.DbContextOptions.UseDm(configurationContext.ConnectionString);
                    });
                }
                else
                {
                    throw new Exception("数据库类型无效");
                }
            });
        }
    }
}
