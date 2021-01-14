using Wzh.AbpVnext.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Wzh.AbpVnext.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpVnextController : AbpController
    {
        protected AbpVnextController()
        {
            LocalizationResource = typeof(AbpVnextResource);
        }
    }
}