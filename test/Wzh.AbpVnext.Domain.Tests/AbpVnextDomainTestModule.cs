using Wzh.AbpVnext.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Wzh.AbpVnext
{
    [DependsOn(
        typeof(AbpVnextEntityFrameworkCoreTestModule)
        )]
    public class AbpVnextDomainTestModule : AbpModule
    {

    }
}