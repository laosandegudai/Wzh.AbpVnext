using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace Wzh.AbpVnext.Articles.Dtos
{
    [Serializable]
    public class ArticleCategoryDto : AuditedEntityDto<Guid>
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
        public List<ArticleCategoryDto> Children { get; set; }
        public Guid? IconId { get; set; }
    }
}