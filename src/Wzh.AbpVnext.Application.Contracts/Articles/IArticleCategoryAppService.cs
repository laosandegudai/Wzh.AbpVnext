using System;
using Wzh.AbpVnext.Articles.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Wzh.AbpVnext.Articles
{
    public interface IArticleCategoryAppService :
        ICrudAppService< 
            ArticleCategoryDto, 
            Guid,
            GetArticleCategoryListInput,
            CreateUpdateArticleCategoryDto,
            CreateUpdateArticleCategoryDto>
    {

    }
}