using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wzh.AbpVnext.Articles
{
    public class ArticleAppServiceTests : AbpVnextApplicationTestBase
    {
        private readonly IArticleAppService _articleAppService;

        public ArticleAppServiceTests()
        {
            _articleAppService = GetRequiredService<IArticleAppService>();
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
