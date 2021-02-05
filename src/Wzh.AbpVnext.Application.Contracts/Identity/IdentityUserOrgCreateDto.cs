using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;

namespace Wzh.AbpVnext.Identity
{
    public class IdentityUserOrgCreateDto: IdentityUserCreateDto
    {
        public List<Guid> OrgIds { get; set; }
    }
}
