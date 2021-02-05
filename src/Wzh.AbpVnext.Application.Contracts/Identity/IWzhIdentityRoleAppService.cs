using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Wzh.AbpVnext.Identity
{
    public interface IWzhIdentityRoleAppService : IApplicationService
    {
        Task AddToOrganizationUnitAsync(Guid roleId, Guid ouId);

        Task<IdentityRoleDto> CreateAsync(IdentityRoleOrgCreateDto input);
    }
}
