using EasyAbp.WeChatManagement.MiniPrograms.Login;
using EasyAbp.WeChatManagement.MiniPrograms.Login.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Wzh.AbpVnext.WeChatManagement.MiniPrograms.Login;

namespace Wzh.AbpVnext.Controllers.WeChatManagement.MiniPrograms.Login
{
    [RemoteService(Name = "EasyAbpWeChatManagementMiniPrograms")]
   
    [ControllerName("Login")]
    [Route("/api/wechat-management/mini-programs/login")]
    public class WzhLoginController : AbpController, IWzhLoginAppService
    {
        private readonly IWzhLoginAppService _service;

        public WzhLoginController(IWzhLoginAppService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("pc-code-login")]
        public Task<PcCodeLoginOutput> PcCodeLoginAsync(PcLoginInput input)
        {
            return _service.PcCodeLoginAsync(input);
        }
    }
}
