using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Wzh.AbpVnext.Identity
{
    public class GetIdentityUsersDetailsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public Guid? RoleId { get; set; }

        public Guid? OrganizationUnitId { get; set; }
    }
}
