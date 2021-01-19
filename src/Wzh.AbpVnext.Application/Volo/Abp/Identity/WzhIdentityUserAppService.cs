﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Wzh.AbpVnext.Features;
using Wzh.AbpVnext.Localization;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;

namespace Volo.Abp.Identity
{
    [RemoteService(IsEnabled = false)]
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IIdentityUserAppService),
        typeof(IdentityUserAppService),
        typeof(IWzhIdentityUserAppService),
        typeof(WzhIdentityUserAppService))]
    public class WzhIdentityUserAppService : IdentityUserAppService, IWzhIdentityUserAppService
    {
        private readonly IStringLocalizer<AbpVnextResource> _localizer;

        public WzhIdentityUserAppService(IdentityUserManager userManager,
            IIdentityUserRepository userRepository,
            IIdentityRoleRepository roleRepository,
            IStringLocalizer<AbpVnextResource> localizer,IOptions<IdentityOptions> identityOptions) : base(userManager, userRepository, roleRepository, identityOptions)
        {
            _localizer = localizer;
        }

        public override async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            var userCount = (await FeatureChecker.GetOrNullAsync(AbpVnextFeatures.UserCount)).To<int>();
            var currentUserCount = await UserRepository.GetCountAsync();
            if (currentUserCount >= userCount)
            {
                throw new UserFriendlyException(_localizer["Feature:UserCount.Maximum", userCount]);
            }

            return await base.CreateAsync(input);
        }

        [Authorize(IdentityPermissions.Users.Create)]
        [Authorize(WzhIdentityPermissions.Users.DistributionOrganizationUnit)]
        public virtual async Task<IdentityUserDto> CreateAsync(IdentityUserOrgCreateDto input)
        {
            var identity = await CreateAsync(
                ObjectMapper.Map<IdentityUserOrgCreateDto, IdentityUserCreateDto>(input)
            );
            if (input.OrgIds != null)
            {
                await UserManager.SetOrganizationUnitsAsync(identity.Id, input.OrgIds.ToArray());
            }
            return identity;
        }

        [Authorize(WzhIdentityPermissions.Users.DistributionOrganizationUnit)]
        public virtual async Task AddToOrganizationUnitsAsync(Guid userId, List<Guid> ouIds)
        {
            await UserManager.SetOrganizationUnitsAsync(userId, ouIds.ToArray());
        }

        public virtual async Task<ListResultDto<OrganizationUnitDto>> GetListOrganizationUnitsAsync(Guid id, bool includeDetails = false)
        {
            var list = await UserRepository.GetOrganizationUnitsAsync(id, includeDetails);
            return new ListResultDto<OrganizationUnitDto>(
                ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(list)
            );
        }

        [Authorize(IdentityPermissions.Users.Update)]
        [Authorize(WzhIdentityPermissions.Users.DistributionOrganizationUnit)]
        public virtual async Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserOrgUpdateDto input)
        {
            var update = ObjectMapper.Map<IdentityUserOrgUpdateDto, IdentityUserUpdateDto>(input);
            var result = await base.UpdateAsync(id, update);
            await UserManager.SetOrganizationUnitsAsync(result.Id, input.OrgIds.ToArray());
            return result;
        }
    }
}
