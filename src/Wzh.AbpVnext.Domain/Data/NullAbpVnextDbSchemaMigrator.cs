using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Wzh.AbpVnext.Data
{
    /* This is used if database provider does't define
     * IAbpVnextDbSchemaMigrator implementation.
     */
    public class NullAbpVnextDbSchemaMigrator : IAbpVnextDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}