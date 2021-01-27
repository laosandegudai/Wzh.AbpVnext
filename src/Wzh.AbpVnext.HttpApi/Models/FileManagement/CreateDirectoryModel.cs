using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wzh.AbpVnext.Models.FileManagement
{
    public class CreateDirectoryModel
    {
        
        public string FileContainerName { get; set; }

        
        public Guid? OwnerUserId { get; set; }

        
        public Guid? ParentId { get; set; }

        
        public string DirectoryName { get; set; }
    }
}
