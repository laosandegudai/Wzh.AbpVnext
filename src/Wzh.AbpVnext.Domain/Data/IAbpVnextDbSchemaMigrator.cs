using System.Threading.Tasks;

namespace Wzh.AbpVnext.Data
{
    public interface IAbpVnextDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
