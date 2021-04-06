using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Wzh.AbpVnext.Articles.Dtos
{
    [Serializable]
    public class CreateUpdateArticleDto
    {
        [Required]
        [Display(Name = "БъЬт")]
        public string Title { get; set; }

        public string LinkUrl { get; set; }

        public Guid? ImgId { get; set; }

        public string Tags { get; set; }

        public string ZhaiYao { get; set; }

        public string Content { get; set; }

        public int? ViewCount { get; set; }

        public int DisplayOrder { get; set; }

        public Guid CategoryId { get; set; }

        public ArticleCategoryDto Category { get; set; }
    }
}