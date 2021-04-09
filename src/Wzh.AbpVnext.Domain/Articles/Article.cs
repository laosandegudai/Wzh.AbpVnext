using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Wzh.AbpVnext.Articles
{
    public class Article : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        /// <summary>
        ///标题
        /// </summary>
        [Display(Name = "标题")]
        [MaxLength(200)]
        public string Title { get; set; }

        /// <summary>
        ///外链
        /// </summary>
        [Display(Name = "外链")]
        [MaxLength(510)]
        public string LinkUrl { get; set; }

        /// <summary>
        ///封面图
        /// </summary>
        [Display(Name = "封面图")]
        [MaxLength(510)]
        public Guid? ImgId { get; set; }

        /// <summary>
        ///标签
        /// </summary>
        [Display(Name = "标签")]
        [MaxLength(200)]
        public string Tags { get; set; }

        /// <summary>
        ///摘要
        /// </summary>
        [Display(Name = "摘要")]
        [MaxLength(255)]
        public string ZhaiYao { get; set; }
        /// <summary>
        ///内容
        /// </summary>
        [Display(Name = "内容")]
        public string Content { get; set; }
        /// <summary>
        ///浏览次数
        /// </summary>
        [Display(Name = "浏览次数")]
        public int? ViewCount { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int DisplayOrder { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        [Display(Name = "分类ID")]
        public Guid CategoryId { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        [Display(Name = "分类")]
        public ArticleCategory Category { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Display(Name = "类型")]
        [MaxLength(100)]
        public string Type { get; set; }

        public Guid? TenantId { get; set; }

        protected Article()
        {
        }

        public Article(
            Guid id,
            string title,
            string linkUrl,
            Guid? imgId,
            string tags,
            string zhaiYao,
            string content,
            int? viewCount,
            int displayOrder,
            Guid categoryId,
            ArticleCategory category
        ) : base(id)
        {
            Title = title;
            LinkUrl = linkUrl;
            ImgId = imgId;
            Tags = tags;
            ZhaiYao = zhaiYao;
            Content = content;
            ViewCount = viewCount;
            DisplayOrder = displayOrder;
            CategoryId = categoryId;
            Category = category;
        }
    }
}
