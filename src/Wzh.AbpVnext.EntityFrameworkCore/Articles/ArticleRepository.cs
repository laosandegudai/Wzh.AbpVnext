using System;
using Wzh.AbpVnext.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Wzh.AbpVnext.Articles
{
    public class ArticleRepository : EfCoreRepository<AbpVnextDbContext, Article, Guid>, IArticleRepository
    {
        public ArticleRepository(IDbContextProvider<AbpVnextDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public override async Task<IQueryable<Article>> WithDetailsAsync()
        {
            var query = await GetQueryableAsync();
            return query.Include(x => x.Category);
        }
    }
}