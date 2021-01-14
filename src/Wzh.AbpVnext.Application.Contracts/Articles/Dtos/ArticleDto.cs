using System;
using Volo.Abp.Application.Dtos;

namespace Wzh.AbpVnext.Articles.Dtos
{
    [Serializable]
    public class ArticleDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string LinkUrl { get; set; }

        public string ImgUrl { get; set; }

        public string Tags { get; set; }

        public string ZhaiYao { get; set; }

        public string Content { get; set; }

        public int? ViewCount { get; set; }

        public int DisplayOrder { get; set; }

        public Guid CategoryId { get; set; }

        public ArticleCategoryDto Category { get; set; }
    }
}