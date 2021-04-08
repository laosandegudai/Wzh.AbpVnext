using System;
using Wzh.AbpVnext.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using EFCore.BulkExtensions;

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
            return query.IncludeDetails();
        }
        public async Task ExecuteStoredProcedure(CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            await dbContext.Database.ExecuteSqlRawAsync(
                "EXEC Pro_XXXX",
                cancellationToken
            );
        }
        public async Task TruncateAsync()
        {
            var dbContext = await GetDbContextAsync();
            await dbContext.TruncateAsync<Article>();
        }
    }
}