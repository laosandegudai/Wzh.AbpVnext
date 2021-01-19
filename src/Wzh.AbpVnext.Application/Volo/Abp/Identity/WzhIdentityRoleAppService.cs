using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Wzh.AbpVnext.Localization;

namespace Volo.Abp.Identity
{
    [RemoteService(IsEnabled = false)]
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IIdentityRoleAppService), 
        typeof(IdentityRoleAppService),
        typeof(IWzhIdentityRoleAppService),
        typeof(WzhIdentityRoleAppService))]
    public class WzhIdentityRoleAppService : IdentityRoleAppService, IWzhIdentityRoleAppService
    {
        private IStringLocalizer<AbpVnextResource> _localizer;
        protected OrganizationUnitManager OrgManager { get; }
        public WzhIdentityRoleAppService(IdentityRoleManager roleManager,
            IIdentityRoleRepository roleRepository,
            IStringLocalizer<AbpVnextResource> localizer,
            OrganizationUnitManager orgManager) : base(roleManager, roleRepository)
        {
            _localizer = localizer;
            OrgManager = orgManager;
        }

        [Authorize(WzhIdentityPermissions.Roles.AddOrganizationUnitRole)]
        public Task AddToOrganizationUnitAsync(Guid roleId, Guid ouId)
        {
            return OrgManager.AddRoleToOrganizationUnitAsync(roleId, ouId);
        }

        [Authorize(IdentityPermissions.Roles.Create)]
        [Authorize(WzhIdentityPermissions.Roles.AddOrganizationUnitRole)]
        public virtual async Task<IdentityRoleDto> CreateAsync(IdentityRoleOrgCreateDto input)
        {
            var role = await base.CreateAsync(
                ObjectMapper.Map<IdentityRoleOrgCreateDto, IdentityRoleCreateDto>(input)
            );
            if (input.OrgId.HasValue)
            {
                await OrgManager.AddRoleToOrganizationUnitAsync(role.Id,input.OrgId.Value);
            }
            return role;
        }
    }
}
