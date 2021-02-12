using Wzh.AbpVnext.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.AuditLogging.Localization;
using Volo.Abp.Identity.Localization;
using EasyAbp.Abp.Trees;
using EasyAbp.FileManagement;
using EasyAbp.FileManagement.Localization;
using EasyAbp.NotificationService;
using EasyAbp.Abp.PhoneNumberLogin;
using EasyAbp.WeChatManagement.MiniPrograms;
using EasyAbp.Abp.SettingUi;
using EasyAbp.Abp.SettingUi.Localization;

namespace Wzh.AbpVnext
{
    [DependsOn(
        typeof(AbpAuditLoggingDomainSharedModule),
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpFeatureManagementDomainSharedModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpIdentityServerDomainSharedModule),
        typeof(AbpPermissionManagementDomainSharedModule),
        typeof(AbpSettingManagementDomainSharedModule),
        typeof(AbpTenantManagementDomainSharedModule),
        typeof(AbpTreesDomainSharedModule),
        typeof(FileManagementDomainSharedModule),
        typeof(NotificationServiceDomainSharedModule),
        typeof(AbpPhoneNumberLoginDomainSharedModule),
        typeof(WeChatManagementMiniProgramsDomainSharedModule)
        )]
    [DependsOn(typeof(SettingUiDomainSharedModule))]
    public class AbpVnextDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AbpVnextGlobalFeatureConfigurator.Configure();
            AbpVnextModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpVnextDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpVnextResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/AbpVnext");

                options.DefaultResourceType = typeof(AbpVnextResource);
                options.Resources
                    .Get<IdentityResource>()
                    .AddVirtualJson("/Localization/Identity");
                options.Resources
                    .Get<AuditLoggingResource>()
                    .AddVirtualJson("/Localization/AuditLogging");
                options.Resources
                    .Get<FileManagementResource>()
                    .AddVirtualJson("/Localization/FileManagement");
                options.Resources
                    .Get<SettingUiResource>()
                    .AddVirtualJson("/Localization/AbpVnext");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("AbpVnext", typeof(AbpVnextResource));
            });
        }
    }
}
