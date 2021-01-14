using Wzh.AbpVnext.Articles;
using Wzh.AbpVnext.Articles.Dtos;
using AutoMapper;
using Volo.Abp.AutoMapper;

namespace Wzh.AbpVnext
{
    public class AbpVnextApplicationAutoMapperProfile : Profile
    {
        public AbpVnextApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<ArticleCategory, ArticleCategoryDto>().Ignore(x => x.Children);
            CreateMap<ArticleCategoryDto, ArticleCategory>();
            CreateMap<CreateUpdateArticleCategoryDto, ArticleCategory>(MemberList.Source);
            CreateMap<Article, ArticleDto>();
            CreateMap<CreateUpdateArticleDto, Article>(MemberList.Source);
        }


    }
}
