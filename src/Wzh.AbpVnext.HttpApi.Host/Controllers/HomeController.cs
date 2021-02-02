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
        public ActionResult Test()
        {
            var dateString = "2021/1/14 下午4:12:03";
            DateTime dt = DateTime.ParseExact(dateString, "yyyy/M/d tth:m:ss", CultureInfo.InvariantCulture);
            return Ok(dt);
        }
    }
}
