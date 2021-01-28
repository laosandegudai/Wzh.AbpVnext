using System;
using Wzh.AbpVnext.Articles.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        Task<byte[]> ExportExcel(GetArticleListInput input);
    }
}