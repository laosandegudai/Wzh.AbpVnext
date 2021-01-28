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

namespace Wzh.AbpVnext.Articles
{
    public class ArticleAppService : CrudAppService<Article, ArticleDto, Guid, GetArticleListInput, CreateUpdateArticleDto, CreateUpdateArticleDto>,
        IArticleAppService
    {
        protected override string GetPolicyName { get; set; } = AbpVnextPermissions.Article.Default;
        protected override string GetListPolicyName { get; set; } = AbpVnextPermissions.Article.Default;
        protected override string CreatePolicyName { get; set; } = AbpVnextPermissions.Article.Create;
        protected override string UpdatePolicyName { get; set; } = AbpVnextPermissions.Article.Update;
        protected override string DeletePolicyName { get; set; } = AbpVnextPermissions.Article.Delete;

        private readonly IArticleRepository _repository;
        
        public ArticleAppService(IArticleRepository repository) : base(repository)
        {
            _repository = repository;
        }
        protected override IQueryable<Article> CreateFilteredQuery(GetArticleListInput input)
        {
            return ReadOnlyRepository.WithDetails()
                .WhereIf(!string.IsNullOrEmpty(input.Filter), x => x.Title.Contains(input.Filter))
                .WhereIf(input.CategoryId != null, x => x.CategoryId == input.CategoryId);
        }
        [RemoteService(false)]
        public async Task<byte[]> ExportExcel(GetArticleListInput input)
        {
            var query = CreateFilteredQuery(input);
            query = ApplySorting(query, input);
            var entities = await AsyncExecuter.ToListAsync(query);
            var entityDtos = ObjectMapper.Map<List<Article>, List<ArticleExportDto>>(entities);
            IExporter exporter = new ExcelExporter();
            var content = await exporter.ExportAsByteArray(entityDtos);
            return content;
        }
    }
}
