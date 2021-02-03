using Magicodes.ExporterAndImporter.Core.Filters;
using Magicodes.ExporterAndImporter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wzh.AbpVnext.Articles
{
    public class ArticleImportResultFilter : IImportResultFilter
    {
        public ImportResult<T> Filter<T>(ImportResult<T> importResult) where T : class, new()
        {
            ///暂时空着
            return importResult;
        }
    }
}
