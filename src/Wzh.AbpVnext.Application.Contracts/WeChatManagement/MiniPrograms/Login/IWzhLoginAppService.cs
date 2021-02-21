using EasyAbp.WeChatManagement.MiniPrograms.Login.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Wzh.AbpVnext.WeChatManagement.MiniPrograms.Login
{
    public interface IWzhLoginAppService : IApplicationService
    {
        Task<PcCodeLoginOutput> PcCodeLoginAsync(PcLoginInput input);
    }
}
