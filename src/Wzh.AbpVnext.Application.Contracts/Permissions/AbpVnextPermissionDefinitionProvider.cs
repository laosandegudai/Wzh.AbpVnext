using Wzh.AbpVnext.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Wzh.AbpVnext.Permissions
{
    public class AbpVnextPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpVnextPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpVnextPermissions.MyPermission1, L("Permission:MyPermission1"));

            var articleCategoryPermission = myGroup.AddPermission(AbpVnextPermissions.ArticleCategory.Default, L("Permission:ArticleCategory"));
            articleCategoryPermission.AddChild(AbpVnextPermissions.ArticleCategory.Create, L("Permission:Create"));
            articleCategoryPermission.AddChild(AbpVnextPermissions.ArticleCategory.Update, L("Permission:Update"));
            articleCategoryPermission.AddChild(AbpVnextPermissions.ArticleCategory.Delete, L("Permission:Delete"));

            var articlePermission = myGroup.AddPermission(AbpVnextPermissions.Article.Default, L("Permission:Article"));
            articlePermission.AddChild(AbpVnextPermissions.Article.Create, L("Permission:Create"));
            articlePermission.AddChild(AbpVnextPermissions.Article.Update, L("Permission:Update"));
            articlePermission.AddChild(AbpVnextPermissions.Article.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpVnextResource>(name);
        }
    }
}
