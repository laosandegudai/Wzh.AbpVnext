using EasyAbp.Abp.PhoneNumberLogin;
using EasyAbp.FileManagement;
using EasyAbp.NotificationService;
using EasyAbp.WeChatManagement.MiniPrograms;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using EasyAbp.Abp.SettingUi;

namespace Wzh.AbpVnext
{
    [DependsOn(
        typeof(AbpVnextApplicationContractsModule),
        typeof(AbpAccountHttpApiClientModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(AbpTenantManagementHttpApiClientModule),
        typeof(AbpFeatureManagementHttpApiClientModule),
        typeof(FileManagementHttpApiClientModule),
        typeof(NotificationServiceHttpApiClientModule),
        typeof(AbpPhoneNumberLoginHttpApiClientModule),
        typeof(WeChatManagementMiniProgramsHttpApiClientModule)
    )]
    [DependsOn(typeof(SettingUiHttpApiClientModule))]
    public class AbpVnextHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpVnextApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
