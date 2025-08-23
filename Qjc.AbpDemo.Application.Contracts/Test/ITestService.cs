using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Qjc.AbpDemo
{
    public interface ITestService: IApplicationService
    {
        Task<string> GetList();

        Task Excute(int row);

        Task<string> GetCurrentUser();
    }
}
