using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Qjc.AbpDemo
{
    public class AbpDemoDbSchemaMigrator: ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public AbpDemoDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            await _serviceProvider.GetRequiredService<AbpDemoDbContext>().Database.MigrateAsync();
        }
    }
}
