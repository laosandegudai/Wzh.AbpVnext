using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wzh.AbpVnext.Articles;
using Wzh.AbpVnext.Articles.Dtos;

namespace Wzh.AbpVnext.Controllers.Articles
{
    [RemoteService(Name = "AbpVnext")]
    [Area("app")]
    [ControllerName("Article")]
    [Route("api/app/article")]
    public class ArticleController : AbpVnextController
    {
        private readonly IArticleAppService _service;
        public ArticleController(IArticleAppService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("export-excel")]
        public async Task<IActionResult> ExportExcel(GetArticleListInput input)
        {
            var content = await _service.ExportExcel(input);
            var memoryStream = new MemoryStream(content);
            return new FileStreamResult(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "Article.xlsx"
            };
        }
    }
}
