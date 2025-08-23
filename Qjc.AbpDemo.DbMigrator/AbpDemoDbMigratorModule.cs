using Qjc.AbpDemo.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Qjc.AbpDemo.DbMigrator
{
    [DependsOn(
        typeof(AbpDemoApplicationModule),
        typeof(AbpAutofacModule)
        )]
    public class AbpDemoDbMigratorModule: AbpModule
    {
    }
}
