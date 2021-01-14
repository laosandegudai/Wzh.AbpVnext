using System;
using Wzh.AbpVnext.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wzh.AbpVnext.Articles
{
    public class ArticleRepository : EfCoreRepository<AbpVnextDbContext, Article, Guid>, IArticleRepository
    {
        public ArticleRepository(IDbContextProvider<AbpVnextDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public override IQueryable<Article> WithDetails()
        {
            return GetQueryable().Include(x => x.Category);
        }
    }
}