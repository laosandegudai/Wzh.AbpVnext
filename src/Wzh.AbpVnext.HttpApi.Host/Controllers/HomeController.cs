using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using Volo.Abp.AspNetCore.Mvc;

namespace Wzh.AbpVnext.Controllers
{
    public class HomeController : AbpController
    {
        public ActionResult Index()
        {
            return Redirect("~/swagger");
        }
        
    }
}
