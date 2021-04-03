using EasyAbp.Abp.PhoneNumberLogin;
using EasyAbp.FileManagement;
using EasyAbp.NotificationService;
using EasyAbp.WeChatManagement.MiniPrograms;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using EasyAbp.Abp.DataDictionary;
using EasyAbp.Abp.SettingUi;
using EasyAbp.Abp.Trees;

namespace Wzh.AbpVnext
{
    [DependsOn(
        typeof(AbpVnextDomainSharedModule),
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule),
        typeof(FileManagementApplicationContractsModule),
        typeof(NotificationServiceApplicationContractsModule),
        typeof(AbpPhoneNumberLoginApplicationContractsModule),
        typeof(WeChatManagementMiniProgramsApplicationContractsModule)
    )]
    [DependsOn(typeof(AbpDataDictionaryApplicationContractsModule))]
    [DependsOn(typeof(AbpDataDictionaryApplicationContractsSharedModule))]
    [DependsOn(typeof(SettingUiApplicationContractsModule))]
    [DependsOn(typeof(AbpTreesApplicationContractsModule))]
    public class AbpVnextApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AbpVnextDtoExtensions.Configure();
        }
    }
}
