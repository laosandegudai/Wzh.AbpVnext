using Localization.Resources.AbpUi;
using Wzh.AbpVnext.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.TenantManagement;
using EasyAbp.FileManagement;
using Volo.Abp.BlobStoring;
using EasyAbp.NotificationService;
using EasyAbp.Abp.PhoneNumberLogin;
using EasyAbp.WeChatManagement.MiniPrograms;
using EasyAbp.Abp.SettingUi;

namespace Wzh.AbpVnext
{
    [DependsOn(
        typeof(AbpVnextApplicationContractsModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule),
        typeof(FileManagementHttpApiModule),
        typeof(AbpBlobStoringModule),
        typeof(NotificationServiceHttpApiModule),
        typeof(AbpPhoneNumberLoginHttpApiModule),
        typeof(WeChatManagementMiniProgramsHttpApiModule)
        )]
    [DependsOn(typeof(SettingUiHttpApiModule))]
    public class AbpVnextHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AbpVnextResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
