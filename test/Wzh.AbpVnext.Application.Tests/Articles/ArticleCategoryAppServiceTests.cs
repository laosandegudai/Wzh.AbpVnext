using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wzh.AbpVnext.Articles
{
    public class ArticleCategoryAppServiceTests : AbpVnextApplicationTestBase
    {
        private readonly IArticleCategoryAppService _articleCategoryAppService;

        public ArticleCategoryAppServiceTests()
        {
            _articleCategoryAppService = GetRequiredService<IArticleCategoryAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
