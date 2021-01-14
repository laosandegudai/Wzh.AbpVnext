using System;
using Wzh.AbpVnext.Articles.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

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

    }
}