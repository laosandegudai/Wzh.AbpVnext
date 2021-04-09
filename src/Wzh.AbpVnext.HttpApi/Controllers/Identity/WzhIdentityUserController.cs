using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;
using Wzh.AbpVnext.Identity;

namespace Wzh.AbpVnext.Controllers.Identity
{
    [RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    [ControllerName("User")]
    [Route("api/identity/users")]
    public class WzhIdentityUserController : AbpController, IWzhIdentityUserAppService
    {
        protected IWzhIdentityUserAppService UserAppService { get; }
        public WzhIdentityUserController(IWzhIdentityUserAppService userAppService)
        {
            UserAppService = userAppService;
        }

        /// <summary>
        /// Add members to the organizational unit
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="ouIds">ouId</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{userId}/add-to-organizations")]
        public virtual Task AddToOrganizationUnitsAsync(Guid userId, List<Guid> ouIds)
        {
            return UserAppService.AddToOrganizationUnitsAsync(userId, ouIds);
        }

        [HttpPost]
        [Route("create-to-organizations")]
        public virtual Task<IdentityUserDto> CreateAsync(IdentityUserOrgCreateDto input)
        {
            return UserAppService.CreateAsync(input);
        }

        [HttpGet]
        [Route("{id}/organizations")]
        public virtual Task<ListResultDto<OrganizationUnitDto>> GetListOrganizationUnitsAsync(Guid id, bool includeDetails = false)
        {
            return UserAppService.GetListOrganizationUnitsAsync(id, includeDetails);
        }

        [HttpPut]
        [Route("{id}/update-to-organizations")]
        public virtual Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserOrgUpdateDto input)
        {
            return UserAppService.UpdateAsync(id, input);
        }
        [HttpGet]
        [Route("details")]
        public Task<PagedResultDto<IdentityUserDetailsDto>> GetListDetailsAsync(GetIdentityUsersDetailsInput input)
        {
            return UserAppService.GetListDetailsAsync(input);
        }


    }
}
