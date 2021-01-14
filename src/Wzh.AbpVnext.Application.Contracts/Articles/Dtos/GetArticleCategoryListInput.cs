using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Wzh.AbpVnext.Articles.Dtos
{
    public class GetArticleCategoryListInput : PagedAndSortedResultRequestDto
    {
        public Guid? ParentId { get; set; }
    }
}
