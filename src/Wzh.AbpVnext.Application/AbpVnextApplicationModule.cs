using EasyAbp.Abp.PhoneNumberLogin;
using EasyAbp.FileManagement;
using EasyAbp.NotificationService;
using EasyAbp.WeChatManagement.MiniPrograms;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.BlobStoring;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using EasyAbp.Abp.SettingUi;
using EasyAbp.Abp.DataDictionary;
using EasyAbp.Abp.Trees;
using Microsoft.Extensions.DependencyInjection;
using Magicodes.ExporterAndImporter.Excel;
using Magicodes.ExporterAndImporter.Core;
using Microsoft.Extensions.Options;
using Volo.Abp;

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
        typeof(AbpPhoneNumberLoginApplicationModule),
        typeof(WeChatManagementMiniProgramsApplicationModule),
        typeof(AbpSettingUiApplicationModule)
        )]
    [DependsOn(typeof(AbpDataDictionaryApplicationModule))]
    [DependsOn(typeof(AbpTreesApplicationModule))]
    public class AbpVnextApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpVnextApplicationModule>();
                context.Services.AddSingleton<IExcelExporter, ExcelExporter>();
                context.Services.AddSingleton<IExcelImporter, ExcelImporter>();
            });
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var options = context.ServiceProvider.GetRequiredService<IOptions<AbpDataDictionaryOptions>>().Value;
            // …®√Ë∆‰À˚ƒ£øÈ°£
            var rules = context.ServiceProvider.GetRequiredService<IDataDictionaryLoader>().ScanRules(typeof(AbpVnextApplicationContractsModule).Assembly);
            options.Rules.AddRange(rules);
        }
    }
}
