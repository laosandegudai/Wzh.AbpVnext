using EasyAbp.Abp.PhoneNumberLogin;
using EasyAbp.FileManagement;
using EasyAbp.NotificationService;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.BlobStoring;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Wzh.AbpVnext
{
    [DependsOn(
        typeof(AbpVnextDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpVnextApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(FileManagementApplicationModule),
        typeof(AbpBlobStoringModule),
        typeof(NotificationServiceApplicationModule),
        typeof(AbpPhoneNumberLoginApplicationModule)
        )]
    public class AbpVnextApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpVnextApplicationModule>();
            });
        }
    }
}
