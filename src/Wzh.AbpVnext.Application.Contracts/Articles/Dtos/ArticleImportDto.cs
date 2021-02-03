using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wzh.AbpVnext.Articles.Dtos
{
    [ExcelImporter(ImportResultFilter = typeof(ArticleImportResultFilter),IsLabelingError = true)]
    public class ArticleImportDto
    {
        [ImporterHeader(Name = "标题")]
        [Required(ErrorMessage = "标题不能为空")]
        public string Title { get; set; }
        [ImporterHeader(Name = "外链")]
        public string LinkUrl { get; set; }
        
        [ImporterHeader(Name = "标签")]
        public string Tags { get; set; }
        [ImporterHeader(Name = "摘要")]
        public string ZhaiYao { get; set; }
        [ImporterHeader(Name = "内容")]
        public string Content { get; set; }
        [ImporterHeader(Name = "浏览次数")]
        public int? ViewCount { get; set; }
        [ImporterHeader(Name = "排序")]
        public int DisplayOrder { get; set; }
        [ImporterHeader(Name = "分类ID")]
        [Required(ErrorMessage = "分类ID不能为空")]
        public Guid CategoryId { get; set; }
        [ImporterHeader(Name = "创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
