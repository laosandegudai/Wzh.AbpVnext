using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Wzh.AbpVnext.Articles.Dtos
{
    public class GetArticleListInput : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public Guid? CategoryId { get; set; }
    }
}
