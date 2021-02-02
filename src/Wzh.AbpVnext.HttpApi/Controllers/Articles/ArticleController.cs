using EasyAbp.FileManagement.Files;
using EasyAbp.FileManagement.Files.Dtos;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Users;
using Wzh.AbpVnext.Articles;
using Wzh.AbpVnext.Articles.Dtos;
using Wzh.AbpVnext.Dtos;

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
        [HttpGet]
        [Route("generate-template")]
        public async Task<IActionResult> GenerateTemplate()
        {
            var content = await _service.GenerateTemplate();
            var memoryStream = new MemoryStream(content);
            return new FileStreamResult(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "ArticleImportTemplate.xlsx"
            };
        }

        [HttpPost]
        [Route("import-excel")]
        [Consumes("multipart/form-data")]
        public async Task<ImportResultDto> ImportExcel(IFormFile file)
        {
            if (file == null)
            {
                throw new NoUploadedFileException();
            }
            var fileName = file.FileName;
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var input = new ImportExcelInput { Bytes = memoryStream.ToArray(), FileName = fileName, MimeType = file.ContentType };
            return await _service.ImportExcel(input);
        }
    }
}
