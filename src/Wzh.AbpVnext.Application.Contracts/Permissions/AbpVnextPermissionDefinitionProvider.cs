using Wzh.AbpVnext.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.Localization;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;

namespace Wzh.AbpVnext.Permissions
{
    public class AbpVnextPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpVnextPermissions.GroupName, AuditLoggingL(AbpVnextPermissions.GroupName));

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


            var identityGroup = context.GetGroup(IdentityPermissions.GroupName);

            var ouPermission = identityGroup.AddPermission(WzhIdentityPermissions.OrganitaionUnits.Default, IdentityL("Permission:OrganitaionUnitManagement"));
            ouPermission.AddChild(WzhIdentityPermissions.OrganitaionUnits.Create, IdentityL("Permission:Create"));
            ouPermission.AddChild(WzhIdentityPermissions.OrganitaionUnits.Update, IdentityL("Permission:Edit"));
            ouPermission.AddChild(WzhIdentityPermissions.OrganitaionUnits.Delete, IdentityL("Permission:Delete"));

            var userPermission = identityGroup.GetPermissionOrNull(IdentityPermissions.Users.Default);
            userPermission?.AddChild(WzhIdentityPermissions.Users.DistributionOrganizationUnit, IdentityL("Permission:DistributionOrganizationUnit"));

            var rolePermission = identityGroup.GetPermissionOrNull(IdentityPermissions.Roles.Default);
            rolePermission?.AddChild(WzhIdentityPermissions.Roles.AddOrganizationUnitRole, IdentityL("Permission:AddOrganizationUnitRole"));

            //Claim
            var claimPermission = identityGroup.AddPermission(WzhIdentityPermissions.ClaimTypes.Default, IdentityL("Permission:ClaimManagement"));
            claimPermission.AddChild(WzhIdentityPermissions.ClaimTypes.Create, IdentityL("Permission:Create"));
            claimPermission.AddChild(WzhIdentityPermissions.ClaimTypes.Update, IdentityL("Permission:Edit"));
            claimPermission.AddChild(WzhIdentityPermissions.ClaimTypes.Delete, IdentityL("Permission:Delete"));

            //AuditLogging
            var auditLogGroup = context.AddGroup(AuditLogPermissions.GroupName, AuditLoggingL(AuditLogPermissions.GroupName));
            var aduditLogPermission = auditLogGroup.AddPermission(AuditLogPermissions.AuditLogs.Default, AuditLoggingL("Permission:AuditLogManagement"));
            aduditLogPermission.AddChild(AuditLogPermissions.AuditLogs.Delete, AuditLoggingL("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpVnextResource>(name);
        }
        private static LocalizableString IdentityL(string name)
        {
            return LocalizableString.Create<IdentityResource>(name);
        }
        private static LocalizableString AuditLoggingL(string name)
        {
            return LocalizableString.Create<AuditLoggingResource>(name);
        }
    }
}
