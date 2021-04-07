using EasyAbp.FileManagement.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace Wzh.AbpVnext.FileManagement
{
    /// <summary>
    /// 后台清理临时文件(比如导入校验失败提供下载的错误数据xlsx)
    /// </summary>
    public class FileCheckJob : BackgroundJob<FileCheckArgs>, ITransientDependency
    {
        private readonly IFileRepository _repository;
        private readonly IFileManager _fileManager;
        public FileCheckJob(IFileRepository repository, IFileManager fileManager)
        {
            _repository = repository;
            _fileManager = fileManager;
        }
        
        public override void Execute(FileCheckArgs args)
        {
            var compareTime = DateTime.Now.AddDays(-7);
            var query = _repository.Where(x => x.FileContainerName== FileContainerNameConsts.Temp && x.CreationTime< compareTime);
            foreach (var item in query)
            {
                AsyncHelper.RunSync(() => _fileManager.DeleteAsync(item));
            }
        }
    }
}
