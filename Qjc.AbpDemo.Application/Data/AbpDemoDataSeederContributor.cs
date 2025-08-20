using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Qjc.AbpDemo
{
    public class AbpDemoDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Test, Guid> TestRepository;

        public AbpDemoDataSeederContributor(IRepository<Test, Guid> testRepository)
        {
            TestRepository = testRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await TestRepository.GetCountAsync() <= 0)
            {
                await TestRepository.InsertAsync(new Test { Name = "1" }, true);
                await TestRepository.InsertAsync(new Test { Name = "2" }, true);
            }
        }
    }
}
