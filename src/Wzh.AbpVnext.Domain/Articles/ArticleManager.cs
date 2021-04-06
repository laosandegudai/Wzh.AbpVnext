using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wzh.AbpVnext.Articles
{
    public class ArticleManager : IArticleManager
    {
        private readonly IArticleRepository _repository;
        public ArticleManager(
            IArticleRepository repository)
        {
            _repository = repository;
        }
    }
}
