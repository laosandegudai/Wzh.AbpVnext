using Wzh.AbpVnext.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Wzh.AbpVnext.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpVnextEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpVnextApplicationContractsModule)
        )]
    public class AbpVnextDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
