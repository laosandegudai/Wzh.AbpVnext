using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Wzh.AbpVnext.TenantManagement.Dtos;

namespace Wzh.AbpVnext.TenantManagement
{
    public interface ITenantAppService: IApplicationService
    {
        Task TenantSwitchAsync(TenantSwitchInput input);
    }
}
