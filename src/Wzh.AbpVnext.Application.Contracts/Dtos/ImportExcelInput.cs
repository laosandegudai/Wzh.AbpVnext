using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Wzh.AbpVnext.Dtos
{
    public class ImportExcelInput
    {
        public byte[] Bytes { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
    }
}
