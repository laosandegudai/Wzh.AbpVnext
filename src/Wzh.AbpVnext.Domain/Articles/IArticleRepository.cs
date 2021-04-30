using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Wzh.AbpVnext.Articles
{
    public interface IArticleRepository : IRepository<Article, Guid>
    {
        Task<IQueryable<ArticleWithDetail>> GetListQueryAsync();
    }
}