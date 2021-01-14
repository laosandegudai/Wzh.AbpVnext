using System;
using Volo.Abp.Domain.Repositories;

namespace Wzh.AbpVnext.Articles
{
    public interface IArticleRepository : IRepository<Article, Guid>
    {
    }
}