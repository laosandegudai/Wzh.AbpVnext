using Microsoft.AspNetCore.Authorization;
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
using Volo.Abp;
using Volo.Abp.Identity;
using Volo.Abp.Domain.Repositories;


namespace Wzh.AbpVnext.Identity
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
        private readonly IRepository<IdentityUser, Guid> _repository;
        private readonly OrganizationUnitManager UnitManager;
        public WzhIdentityUserAppService(IdentityUserManager userManager,
            IIdentityUserRepository userRepository,
            IIdentityRoleRepository roleRepository,
            IStringLocalizer<AbpVnextResource> localizer,
            IOptions<Microsoft.AspNetCore.Identity.IdentityOptions> identityOptions,
            OrganizationUnitManager unitManager,
            IRepository<IdentityUser, Guid> repository) : base(userManager, userRepository, roleRepository, identityOptions)
        {
            _localizer = localizer;
            _repository = repository;
            UnitManager = unitManager;
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


        [Authorize(IdentityPermissions.Users.Default)]
        public virtual async Task<PagedResultDto<IdentityUserDetailsDto>> GetListDetailsAsync(GetIdentityUsersDetailsInput input)
        {
            var query= await CreateFilteredQueryAsync(input);
            query = query.PageBy(input.SkipCount, input.MaxResultCount);
            var list = await AsyncExecuter.ToListAsync(query);
            var count = await AsyncExecuter.CountAsync(query);

            return new PagedResultDto<IdentityUserDetailsDto>(
                count,
                ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDetailsDto>>(list)
            );
        }
        public virtual async Task<IQueryable<IdentityUser>> CreateFilteredQueryAsync(GetIdentityUsersDetailsInput input)
        {
            var query = await _repository.WithDetailsAsync();
            //if (input.OrganizationUnitId != null)
            //{
            //    var code = await UnitManager.GetCodeOrDefaultAsync(input.OrganizationUnitId.Value);
            //    var organizationUnitIds = (await UnitManager.FindChildrenAsync(input.OrganizationUnitId.Value, true)).Select(x => x.Id);
            //    query = query.Where(x => x.OrganizationUnits.Any(o => organizationUnitIds.Contains(o.OrganizationUnitId)));
            //}
            return query
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    u =>
                        u.UserName.Contains(input.Filter) ||
                        u.Email.Contains(input.Filter) ||
                        (u.Name != null && u.Name.Contains(input.Filter)) ||
                        (u.Surname != null && u.Surname.Contains(input.Filter)) ||
                        (u.PhoneNumber != null && u.PhoneNumber.Contains(input.Filter))
                )
                .WhereIf(input.RoleId != null, u => u.Roles.Any(x => x.RoleId == input.RoleId))
                .WhereIf(input.OrganizationUnitId != null, u => u.OrganizationUnits.Any(x => x.OrganizationUnitId == input.OrganizationUnitId))
                ;
        }
    }
}
