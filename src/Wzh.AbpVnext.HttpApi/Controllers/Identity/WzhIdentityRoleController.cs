using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;
using Wzh.AbpVnext.Identity;

namespace Wzh.AbpVnext.Controllers.Identity
{
    [RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    [ControllerName("Role")]
    [Route("api/identity/roles")]
    public class WzhIdentityRoleController : AbpController, IWzhIdentityRoleAppService
    {
        protected IWzhIdentityRoleAppService RoleAppService { get; }
        public WzhIdentityRoleController(IWzhIdentityRoleAppService roleAppService)
        {
            RoleAppService = roleAppService;
        }

        [HttpPost]
        [Route("{roleId}/add-to-organization/{ouId}")]
        public virtual Task AddToOrganizationUnitAsync(Guid roleId, Guid ouId)
        {
            return RoleAppService.AddToOrganizationUnitAsync(roleId, ouId);
        }

        [HttpPost]
        [Route("create-to-organization")]
        public Task<IdentityRoleDto> CreateAsync(IdentityRoleOrgCreateDto input)
        {
            return RoleAppService.CreateAsync(input);
        }
    }
}
