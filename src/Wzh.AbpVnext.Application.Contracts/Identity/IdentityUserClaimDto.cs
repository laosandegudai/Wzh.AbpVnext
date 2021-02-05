using System;

namespace Wzh.AbpVnext.Identity
{
	public class IdentityUserClaimDto
	{
		public Guid UserId { get; set; }

		public string ClaimType { get; set; }

		public string ClaimValue { get; set; }
	}
}
