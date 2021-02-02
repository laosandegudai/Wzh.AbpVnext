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
        typeof(AbpBlobStoringModule)
        )]
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
