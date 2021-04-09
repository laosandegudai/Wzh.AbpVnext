﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace Wzh.AbpVnext.Identity
{
    public interface IWzhIdentityUserAppService : IApplicationService
    {
        Task AddToOrganizationUnitsAsync(Guid userId, List<Guid> ouId);


        /// <summary>
        /// get list OrganizationUnits
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        Task<ListResultDto<OrganizationUnitDto>> GetListOrganizationUnitsAsync(Guid id, bool includeDetails = false);


        Task<IdentityUserDto> CreateAsync(IdentityUserOrgCreateDto input);

        Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserOrgUpdateDto input);
        Task<PagedResultDto<IdentityUserDetailsDto>> GetListDetailsAsync(GetIdentityUsersDetailsInput input);
    }
}
