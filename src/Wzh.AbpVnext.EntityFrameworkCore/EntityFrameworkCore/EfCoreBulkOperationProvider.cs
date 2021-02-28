using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace Wzh.AbpVnext.EntityFrameworkCore
{
    public class EfCoreBulkOperationProvider : IEfCoreBulkOperationProvider, ITransientDependency
    {
        async Task IEfCoreBulkOperationProvider.DeleteManyAsync<TDbContext, TEntity>(IEfCoreRepository<TEntity> repository, IEnumerable<TEntity> entities, bool autoSave, CancellationToken cancellationToken)
        {
            var dbContext = await repository.GetDbContextAsync();
            await dbContext.BulkDeleteAsync(entities.ToList());
            if (autoSave)
            {
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        async Task IEfCoreBulkOperationProvider.InsertManyAsync<TDbContext, TEntity>(IEfCoreRepository<TEntity> repository, IEnumerable<TEntity> entities, bool autoSave, CancellationToken cancellationToken)
        {

            var dbContext = await repository.GetDbContextAsync();
            var list = entities.ToList();
            await dbContext.BulkInsertAsync(entities.ToList());
            if (autoSave)
            {
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        async Task IEfCoreBulkOperationProvider.UpdateManyAsync<TDbContext, TEntity>(IEfCoreRepository<TEntity> repository, IEnumerable<TEntity> entities, bool autoSave, CancellationToken cancellationToken)
        {
            var dbContext = await repository.GetDbContextAsync();
            await dbContext.BulkUpdateAsync(entities.ToList());
            if (autoSave)
            {
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
