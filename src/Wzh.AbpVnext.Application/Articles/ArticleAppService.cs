using System;
using Wzh.AbpVnext.Permissions;
using Wzh.AbpVnext.Articles.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Magicodes.ExporterAndImporter.Core.Models;
using Wzh.AbpVnext.Dtos;
using Volo.Abp.Validation;
using EasyAbp.FileManagement.Files;
using EasyAbp.FileManagement.Files.Dtos;

namespace Wzh.AbpVnext.Articles
{
    [Authorize(AbpVnextPermissions.Article.Default)]
    public class ArticleAppService : CrudAppService<Article, ArticleDto, Guid, GetArticleListInput, CreateUpdateArticleDto, CreateUpdateArticleDto>,
        IArticleAppService
    {
        protected override string GetPolicyName { get; set; } = AbpVnextPermissions.Article.Default;
        protected override string GetListPolicyName { get; set; } = AbpVnextPermissions.Article.Default;
        protected override string CreatePolicyName { get; set; } = AbpVnextPermissions.Article.Create;
        protected override string UpdatePolicyName { get; set; } = AbpVnextPermissions.Article.Update;
        protected override string DeletePolicyName { get; set; } = AbpVnextPermissions.Article.Delete;

        private readonly IArticleRepository _repository;
        private readonly IFileAppService _fileService;
        public ArticleAppService(IArticleRepository repository,IFileAppService fileService) : base(repository)
        {
            _repository = repository;
            _fileService = fileService;
        }
        protected override async Task<IQueryable<Article>> CreateFilteredQueryAsync(GetArticleListInput input)
        {
            var query = await ReadOnlyRepository.WithDetailsAsync();
            return query
                .WhereIf(!string.IsNullOrEmpty(input.Filter), x => x.Title.Contains(input.Filter))
                .WhereIf(input.CategoryId != null, x => x.CategoryId == input.CategoryId);
        }
        [Authorize(AbpVnextPermissions.Article.Delete)]
        public async Task DeleteAsync(List<Guid> ids)
        {
            await _repository.DeleteAsync(x => ids.Contains(x.Id));
        }
        [RemoteService(false)]
        public async Task<byte[]> ExportExcel(GetArticleListInput input)
        {
            var query = await CreateFilteredQueryAsync(input);
            query = ApplySorting(query, input);
            var entities = await AsyncExecuter.ToListAsync(query);
            var entityDtos = ObjectMapper.Map<List<Article>, List<ArticleExportDto>>(entities);
            IExporter exporter = new ExcelExporter();
            var content = await exporter.ExportAsByteArray(entityDtos);
            return content;
        }
        [RemoteService(false)]
        public async Task<byte[]> GenerateTemplate()
        {
            IImporter Importer = new ExcelImporter();
            var content = await Importer.GenerateTemplateBytes<ArticleImportDto>();
            return content;
        }
        [RemoteService(false)]
        public async Task<ImportResultDto> ImportExcel(ImportExcelInput input)
        {
            IExcelImporter Importer = new ExcelImporter();
            var stream = new MemoryStream(input.Bytes);
            var import = await Importer.Import<ArticleImportDto>(stream);
            var result = new ImportResultDto
            {
                HasError = import.HasError,
                RowErrors = import.RowErrors,
                TemplateErrors = import.TemplateErrors,
            };
            if (import.RowErrors!=null&& import.RowErrors.Count>0)
            {
                var newStream= new MemoryStream(stream.ToArray());
                Importer.OutputBussinessErrorData<ArticleImportDto>(newStream, import.RowErrors.ToList(), out byte[] fileByte);
                var createFileOutput = await _fileService.CreateAsync(new CreateFileInput
                {
                    FileContainerName = "temp",
                    FileName = input.FileName,
                    MimeType = input.MimeType,
                    FileType = FileType.RegularFile,
                    ParentId = null,
                    OwnerUserId = CurrentUser.Id,
                    Content = fileByte
                });
                result.ErrorFile = createFileOutput;
                return result;
            }
            var entitys = ObjectMapper.Map<List<ArticleImportDto>, List<Article>>(import.Data.ToList());
            await _repository.InsertManyAsync(entitys);
            return result;
        }
    }
}
