using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qjc.AbpDemo.Application.Data
{
    public class AbpDemoDbContextFactory: IDesignTimeDbContextFactory<AbpDemoDbContext>
    {
        public AbpDemoDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            string dataBaseType = configuration["DataBaseType"];
            var builder = new DbContextOptionsBuilder<AbpDemoDbContext>();
            if (dataBaseType.Equals("SqlServer"))
            {
                builder.UseSqlServer(configuration["ConnectionStrings:SqlServer"]);
            }
            else if (dataBaseType.Equals("Dm"))
            {
                builder.UseDm(configuration["ConnectionStrings:Dm"]);
            }
            else
            {
                throw new Exception("数据库类型无效");
            }
            return new AbpDemoDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Qjc.AbpDemo.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);
            return builder.Build();
        }
    }
}
