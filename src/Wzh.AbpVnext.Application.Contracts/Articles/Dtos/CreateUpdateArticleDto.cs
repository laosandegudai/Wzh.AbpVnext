using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Wzh.AbpVnext.Articles.Dtos
{
    [Serializable]
    public class CreateUpdateArticleDto
    {
        /// <summary>
        /// ����
        /// </summary>
        [Required]
        [Display(Name = "����")]
        public string Title { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string LinkUrl { get; set; }
        /// <summary>
        /// ����ͼ
        /// </summary>
        public Guid? ImgId { get; set; }
        /// <summary>
        /// ��ǩ
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// ժҪ
        /// </summary>
        public string ZhaiYao { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public int? ViewCount { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public Guid CategoryId { get; set; }

        public ArticleCategoryDto Category { get; set; }
        public string Type { get; set; }
    }
}