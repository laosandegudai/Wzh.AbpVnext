using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wzh.AbpVnext.Articles
{
    public static class ArticleEfCoreQueryableExtensions
    {
        public static IQueryable<Article> IncludeDetails(this IQueryable<Article> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                 .Include(x => x.Category) // TODO: AbpHelper generated
                ;
        }
    }
}