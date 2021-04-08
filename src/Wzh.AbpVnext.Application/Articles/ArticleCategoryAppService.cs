using System;
using Wzh.AbpVnext.Permissions;
using Wzh.AbpVnext.Articles.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Wzh.AbpVnext.Articles
{
    [Authorize(AbpVnextPermissions.ArticleCategory.Default)]
    public class ArticleCategoryAppService : CrudAppService<ArticleCategory, ArticleCategoryDto, Guid, GetArticleCategoryListInput, CreateUpdateArticleCategoryDto, CreateUpdateArticleCategoryDto>,
        IArticleCategoryAppService
    {
        protected override string GetPolicyName { get; set; } = AbpVnextPermissions.ArticleCategory.Default;
        protected override string GetListPolicyName { get; set; } = AbpVnextPermissions.ArticleCategory.Default;
        protected override string CreatePolicyName { get; set; } = AbpVnextPermissions.ArticleCategory.Create;
        protected override string UpdatePolicyName { get; set; } = AbpVnextPermissions.ArticleCategory.Update;
        protected override string DeletePolicyName { get; set; } = AbpVnextPermissions.ArticleCategory.Delete;

        private readonly IArticleCategoryRepository _repository;
        
        public ArticleCategoryAppService(
            IArticleCategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }
        [Authorize(AbpVnextPermissions.ArticleCategory.Delete)]
        public async Task DeleteAsync(List<Guid> ids)
        {
            foreach (var item in ids)
            {
                await _repository.DeleteAsync(item);
            }
        }
        [Authorize(AbpVnextPermissions.ArticleCategory.Default)]
        public async Task<List<ArticleCategoryDto>> GetTreesAsync()
        {
            var root = await _repository.GetChildrenAsync(null,false);
            var rootDto = ObjectMapper.Map<List<ArticleCategory>, List<ArticleCategoryDto>>(root.OrderBy(x=>x.DisplayOrder).ToList());
            foreach (var ouDto in rootDto)
            {
                await TraverseTreeAsync(ouDto, ouDto.Children);
            }
            return rootDto;
        }
        private async Task TraverseTreeAsync(ArticleCategoryDto dto, List<ArticleCategoryDto> children)
        {
            if (dto.Children==null)
            {
                dto.Children = new List<ArticleCategoryDto>();
            }
            if (dto.Children.Count == 0)
            {
                var childrenList = await _repository.GetChildrenAsync(dto.Id, false);
                children = ObjectMapper.Map<List<ArticleCategory>, List<ArticleCategoryDto>>(childrenList);
                if (children == null || !children.Any())
                {
                    await Task.CompletedTask;
                    return;
                }
                dto.Children?.AddRange(children.OrderBy(x => x.DisplayOrder));
            }
            if (children == null || !children.Any())
            {
                await Task.CompletedTask;
                return;
            }
            foreach (var child in children)
            {
                var next = ObjectMapper.Map<List<ArticleCategory>, List<ArticleCategoryDto>>(await _repository.GetChildrenAsync(child.Id, false));
                if (next == null || !next.Any())
                {
                    await Task.CompletedTask;
                    return;
                }
                child.Children?.AddRange(next.OrderBy(x => x.DisplayOrder));
                await TraverseTreeAsync(child, child.Children);
            }
        }
        
    }
}
