using System;
using System.Threading.Tasks;
using Wzh.AbpVnext.Articles;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wzh.AbpVnext.EntityFrameworkCore.Articles
{
    public class ArticleRepositoryTests : AbpVnextEntityFrameworkCoreTestBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleRepositoryTests()
        {
            _articleRepository = GetRequiredService<IArticleRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
