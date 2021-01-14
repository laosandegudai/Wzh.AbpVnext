using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Wzh.AbpVnext
{
    [Dependency(ReplaceServices = true)]
    public class AbpVnextBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpVnext";
    }
}
