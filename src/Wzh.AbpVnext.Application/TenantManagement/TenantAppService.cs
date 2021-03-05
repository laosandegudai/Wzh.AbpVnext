using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Wzh.AbpVnext.TenantManagement.Dtos;

namespace Wzh.AbpVnext.TenantManagement
{
    public class TenantAppService : TenantManagementAppServiceBase, ITenantAppService
    {
        protected ITenantStore TenantStore { get; }
        public TenantAppService(ITenantStore tenantStore)
        {
            TenantStore = tenantStore;
        }
        [RemoteService(IsMetadataEnabled = false)]
        public async Task TenantSwitchAsync(TenantSwitchInput input)
        {
            if (input.Name.IsNullOrEmpty())
            {
                return;
            }
            var tenant = await TenantStore.FindAsync(input.Name);
            if (tenant==null)
            {
                throw new UserFriendlyException("查询的租户不存在或不可用");
            }
            return;
        }
    }
}
