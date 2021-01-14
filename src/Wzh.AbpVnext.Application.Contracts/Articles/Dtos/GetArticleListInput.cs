using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Wzh.AbpVnext.Articles.Dtos
{
    public class GetArticleListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
