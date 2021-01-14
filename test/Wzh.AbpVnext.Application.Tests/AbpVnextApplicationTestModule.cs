using Volo.Abp.Modularity;

namespace Wzh.AbpVnext
{
    [DependsOn(
        typeof(AbpVnextApplicationModule),
        typeof(AbpVnextDomainTestModule)
        )]
    public class AbpVnextApplicationTestModule : AbpModule
    {

    }
}