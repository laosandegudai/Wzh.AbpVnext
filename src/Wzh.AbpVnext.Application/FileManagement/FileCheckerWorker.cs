using EasyAbp.FileManagement.Files;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;
using Volo.Abp.Uow;

namespace Wzh.AbpVnext.FileManagement
{
    public class FileCheckerWorker : AsyncPeriodicBackgroundWorkerBase
    {
        public FileCheckerWorker(
                AbpAsyncTimer timer,
                IServiceScopeFactory serviceScopeFactory
            ) : base(
                timer,
                serviceScopeFactory)
        {
            Timer.Period = 600000; //10 minutes
        }
        [UnitOfWork]
        protected async override Task DoWorkAsync(
            PeriodicBackgroundWorkerContext workerContext)
        {
            Logger.LogInformation("Starting: Setting status of inactive FileChecker...");

            var _repository = workerContext
                .ServiceProvider
                .GetRequiredService<IFileRepository>();

            var compareTime = DateTime.Now.AddDays(-7);
            var query =  (await _repository.GetQueryableAsync()).Where(x => x.FileContainerName == FileContainerNameConsts.Temp && x.CreationTime < compareTime);

            Logger.LogInformation("Completed: Setting status of inactive FileChecker...");
        }
    }
}
