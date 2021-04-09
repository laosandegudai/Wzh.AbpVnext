using Wzh.AbpVnext.Articles;
using Wzh.AbpVnext.Articles.Dtos;
using AutoMapper;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.AuditLogging;
using EasyAbp.FileManagement.Files.Dtos;
using EasyAbp.FileManagement.Files;
using Wzh.AbpVnext.Identity;
using Wzh.AbpVnext.AuditLogging;
using System.Linq;

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
            CreateMap<Article, ArticleExportDto>();
            CreateMap<ArticleImportDto, Article>();

            CreateMap<OrganizationUnit, OrganizationUnitDto>()
                .MapExtraProperties();

            CreateMap<IdentityUserOrgCreateDto, IdentityUserCreateDto>();
            CreateMap<IdentityUserOrgUpdateDto, IdentityUserUpdateDto>();
            CreateMap<IdentityUser, IdentityUserDetailsDto>();

            CreateMap<IdentityRoleOrgCreateDto, IdentityRoleCreateDto>();



            //AuditLog
            CreateMap<AuditLog, AuditLogDto>()
                .MapExtraProperties();
            CreateMap<AuditLog, AuditLogExportDto>();

            CreateMap<EntityChange, EntityChangeDto>()
                .MapExtraProperties();

            CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();

            CreateMap<AuditLogAction, AuditLogActionDto>();

            //Claim
            CreateMap<IdentityClaimType, ClaimTypeDto>().Ignore(x => x.ValueTypeAsString);
            CreateMap<IdentityUserClaim, IdentityUserClaimDto>();
            CreateMap<IdentityUserClaimDto, IdentityUserClaim>().Ignore(x => x.TenantId).Ignore(x => x.Id);
            CreateMap<IdentityRoleClaim, IdentityRoleClaimDto>();
            CreateMap<IdentityRoleClaimDto, IdentityRoleClaim>().Ignore(x => x.TenantId).Ignore(x => x.Id);
            CreateMap<CreateClaimTypeDto, IdentityClaimType>().Ignore(x => x.IsStatic).Ignore(x => x.Id);
            CreateMap<UpdateClaimTypeDto, IdentityClaimType>().Ignore(x => x.IsStatic).Ignore(x => x.Id);

            CreateMap<FileInfoDto, File>();
        }


    }
}
