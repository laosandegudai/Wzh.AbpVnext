using EasyAbp.FileManagement.Files;
using EasyAbp.FileManagement.Files.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Wzh.AbpVnext.Models.FileManagement;

namespace Wzh.AbpVnext.Controllers.FileManagement
{
    [RemoteService(Name = "EasyAbpFileManagement")]
    [Area("file-management")]
    [ControllerName("File")]
    [Route("api/file-management/file")]
    public class FileController : AbpVnextController
    {
        private readonly IFileAppService _service;
        private readonly IFileRepository _repository;
        private readonly IFileManager _fileManager;
        public FileController(IFileAppService service, IFileRepository repository, IFileManager fileManager)
        {
            _service = service;
            _repository = repository;
            _fileManager = fileManager;
        }
        [HttpPost]
        [Route("create-directory")]
        public async Task CreateDirectoryAsync(CreateDirectoryModel input)
        {
            var dto = new CreateFileInput
            {
                FileContainerName = input.FileContainerName,
                OwnerUserId = input.OwnerUserId,
                FileName = input.DirectoryName,
                FileType = FileType.Directory,
                MimeType = null,
                ParentId = input.ParentId,
                Content = null
            };
            await _service.CreateAsync(dto);
        }
        [HttpPost]
        [Route("upload")]
        [Consumes("multipart/form-data")]
        public async Task<CreateFileOutput> UploadAsync(IFormFile file)
        {
            if (file == null)
            {
                throw new NoUploadedFileException();
            }
            var fileName = file.FileName;
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return await _service.CreateAsync(new CreateFileInput
            {
                FileContainerName = "default",
                FileName = fileName,
                MimeType = file.ContentType,
                FileType = FileType.RegularFile,
                ParentId = null,
                OwnerUserId = CurrentUser.Id,
                Content = memoryStream.ToArray()
            });
        }
        [HttpGet]
        [Route("{id}/getFile")]
        public async Task<IActionResult> GetFileAsync(Guid id)
        {
            var file = await _repository.GetAsync(id);
            var content = await _fileManager.GetBlobAsync(file);
            var memoryStream = new MemoryStream(content);
            return new FileStreamResult(memoryStream, file.MimeType)
            {
                FileDownloadName = file.FileName
            };
        }
    }
}
