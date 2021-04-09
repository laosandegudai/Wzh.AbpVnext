using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Wzh.AbpVnext.Identity
{
    public interface IWzhIdentityUserRepository : IRepository<IdentityUser, Guid>
    {
        Task<long> GetCountAsync(
            string filter = null,
            Guid? roleId = null,
            Guid? oId = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default);
        Task<List<IdentityUser>> GetListAsync(
           string sorting = null,
           int maxResultCount = int.MaxValue,
           int skipCount = 0,
           string filter = null,
           Guid? roleId = null,
           Guid? oId = null,
           bool includeDetails = false,
           CancellationToken cancellationToken = default);
    }
}
