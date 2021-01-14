using System;
using System.Collections.Generic;
using System.Text;
using Wzh.AbpVnext.Localization;
using Volo.Abp.Application.Services;

namespace Wzh.AbpVnext
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpVnextAppService : ApplicationService
    {
        protected AbpVnextAppService()
        {
            LocalizationResource = typeof(AbpVnextResource);
        }
    }
}
