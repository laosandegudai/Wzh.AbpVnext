using System;
using Wzh.AbpVnext.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Entities;
using EasyAbp.Abp.Trees;
using System.Linq;


namespace Wzh.AbpVnext.Articles
{
    public class ArticleCategoryRepository : EasyAbp.Abp.Trees.EfCoreTreeRepository<AbpVnextDbContext, ArticleCategory>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(IDbContextProvider<AbpVnextDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
        
    }
}