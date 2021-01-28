using Magicodes.ExporterAndImporter.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wzh.AbpVnext.Articles.Dtos
{
    public class ArticleExportDto
    {
        [ExporterHeader(DisplayName = "标题")]
        public string Title { get; set; }
        [ExporterHeader(DisplayName = "外链")]
        public string LinkUrl { get; set; }
        [ExporterHeader(DisplayName = "封面图")]
        public string ImgUrl { get; set; }
        [ExporterHeader(DisplayName = "标签")]
        public string Tags { get; set; }
        [ExporterHeader(DisplayName = "摘要")]
        public string ZhaiYao { get; set; }
        [ExporterHeader(DisplayName = "内容")]
        public string Content { get; set; }
        [ExporterHeader(DisplayName = "浏览次数")]
        public int? ViewCount { get; set; }
        [ExporterHeader(DisplayName = "排序")]
        public int DisplayOrder { get; set; }
        [ExporterHeader(DisplayName = "分类ID")]
        public Guid CategoryId { get; set; }
        [ExporterHeader(DisplayName = "创建时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime CreationTime { get; set; }
    }
}
