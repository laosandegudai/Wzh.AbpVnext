using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Wzh.AbpVnext.Articles.Dtos
{
    [Serializable]
    public class CreateUpdateArticleCategoryDto
    {
        public string DisplayName { get; set; }

        public string Code { get; set; }

        public int Level { get; set; }

        public ArticleCategoryDto Parent { get; set; }

        public Guid? ParentId { get; set; }
        /// <summary>
        /// ≈≈–Ú
        /// </summary>
        [Display(Name = "≈≈–Ú")]
        public int DisplayOrder { get; set; }
        //public ICollection<ArticleCategoryDto> Children { get; set; }
        public Guid? IconId { get; set; }
    }
}