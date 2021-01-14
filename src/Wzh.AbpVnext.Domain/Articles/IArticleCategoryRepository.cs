using EasyAbp.Abp.Trees;
using System;
using Volo.Abp.Domain.Repositories;

namespace Wzh.AbpVnext.Articles
{
    public interface IArticleCategoryRepository : ITreeRepository<ArticleCategory>
    {
    }
}