using System;
using Wzh.AbpVnext.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using EFCore.BulkExtensions;
using Wzh.AbpVnext.Users;

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
        public async Task<IQueryable<ArticleWithDetail>> GetListQueryAsync()
        {
            var dbSet = await GetDbSetAsync();
            var userDbSet = (await GetDbContextAsync()).Set<AppUser>();
            var query = from article in dbSet
                        join user in (await GetDbContextAsync()).Set<AppUser>() on article.CreatorId equals user.Id into userJoined
                        from user in userJoined.DefaultIfEmpty()
                        select new ArticleWithDetail
                        {
                            Article = article,
                            Creator = user
                        };
            return query;
        }
    }
}