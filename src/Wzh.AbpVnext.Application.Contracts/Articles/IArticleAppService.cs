using System;
using Wzh.AbpVnext.Articles.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Magicodes.ExporterAndImporter.Core.Models;
using Wzh.AbpVnext.Dtos;
using System.IO;
using EasyAbp.FileManagement.Files.Dtos;

namespace Wzh.AbpVnext.Articles
{
    public interface IArticleAppService :
        ICrudAppService< 
            ArticleDto, 
            Guid,
            GetArticleListInput,
            CreateUpdateArticleDto,
            CreateUpdateArticleDto>
    {
        Task DeleteAsync(List<Guid> ids);
        Task<byte[]> ExportExcel(GetArticleListInput input);
        Task<byte[]> GenerateTemplate();
        Task<ImportResultDto> ImportExcel(ImportExcelInput input);
    }
}