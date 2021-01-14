using System;
using Wzh.AbpVnext.Permissions;
using Wzh.AbpVnext.Articles.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

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


    }
}
