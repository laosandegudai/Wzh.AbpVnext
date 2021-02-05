using Volo.Abp.Application.Dtos;

namespace Wzh.AbpVnext.Identity
{
	public class GetIdentityClaimTypesInput : PagedAndSortedResultRequestDto
	{
		public string Filter { get; set; }

	}
}
