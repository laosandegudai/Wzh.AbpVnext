using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wzh.AbpVnext.Users;

namespace Wzh.AbpVnext.Articles
{
    public class ArticleWithDetail
    {
        public Article Article { get; set; }

        public AppUser Creator { get; set; }
    }
}
