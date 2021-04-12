using EasyAbp.Abp.DataDictionary;
using System;
using Volo.Abp.Application.Dtos;

namespace Wzh.AbpVnext.Articles.Dtos
{
    [Serializable]
    public class ArticleDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// ����
        /// </summary>
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
        /// <summary>
        /// ��������
        /// </summary>
        [DictionaryCodeField("ArticleType")]
        [DictionaryRenderField("ArticleType")]
        public string Type { get; set; }
    }
}