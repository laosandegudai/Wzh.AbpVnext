using System;
using System.Threading.Tasks;
using Wzh.AbpVnext.Articles;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wzh.AbpVnext.EntityFrameworkCore.Articles
{
    public class ArticleCategoryRepositoryTests : AbpVnextEntityFrameworkCoreTestBase
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryRepositoryTests()
        {
            _articleCategoryRepository = GetRequiredService<IArticleCategoryRepository>();
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
