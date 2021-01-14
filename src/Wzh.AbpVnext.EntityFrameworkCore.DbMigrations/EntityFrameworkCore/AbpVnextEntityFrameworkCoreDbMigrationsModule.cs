using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Wzh.AbpVnext.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpVnextEntityFrameworkCoreModule)
        )]
    public class AbpVnextEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpVnextMigrationsDbContext>();
        }
    }
}
