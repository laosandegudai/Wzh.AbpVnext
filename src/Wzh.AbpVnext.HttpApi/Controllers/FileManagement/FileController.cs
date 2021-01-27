using EasyAbp.FileManagement.Files;
using EasyAbp.FileManagement.Files.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public FileController(IFileAppService service)
        {
            _service = service;
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
        public async Task UploadAsync(UploadModel input)
        {
            var dto = new CreateManyFileInput { FileInfos = new List<CreateFileInput>() };
            foreach (var uploadedFile in input.UploadedFiles)
            {
                dto.FileInfos.Add(new CreateFileInput
                {
                    FileContainerName = input.FileContainerName,
                    OwnerUserId = input.OwnerUserId,
                    FileName = uploadedFile.FileName,
                    FileType = FileType.RegularFile,
                    MimeType = uploadedFile.ContentType,
                    ParentId = input.ParentId,
                    Content = await uploadedFile.GetAllBytesAsync()
                });
            }

            await _service.CreateManyAsync(dto);
        }
    }
}
