using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Security.Claims;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace Qjc.AbpDemo.Test
{
    public class TestService: ApplicationService, ITestService
    {
        private readonly ICurrentUser CurrentUser;

        private readonly IRepository<Test, Guid> TestRepository;

        public TestService(IRepository<Test, Guid> testRepository, ICurrentUser currentUser)
        {
            TestRepository = testRepository;
            CurrentUser = currentUser;
        }

        public async Task<string> GetList()
        {
            return JsonSerializer.Serialize(await TestRepository.GetListAsync());
        }

        public async Task Excute(int row)
        {
            long index = await TestRepository.GetCountAsync();
            for (int i = 0; i < row; i++)
            {
                index++;
                await TestRepository.InsertAsync(new Test { Name = index.ToString() }, autoSave: true);
            }
        }

        public async Task<string> GetCurrentUser()
        {
            return await Task.FromResult(JsonSerializer.Serialize(CurrentUser));
        }
    }
}
