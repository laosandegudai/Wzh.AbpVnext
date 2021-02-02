using EasyAbp.FileManagement.Files.Dtos;
using Magicodes.ExporterAndImporter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wzh.AbpVnext.Dtos
{
    public class ImportResultDto
    {
        public bool HasError { get; set; }
        public IList<DataRowErrorInfo> RowErrors { get; set; }
        public IList<TemplateErrorInfo> TemplateErrors { get; set; }
        public CreateFileOutput ErrorFile { get; set; }
    }
}
