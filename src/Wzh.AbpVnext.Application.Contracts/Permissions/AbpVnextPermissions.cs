namespace Wzh.AbpVnext.Permissions
{
    public static class AbpVnextPermissions
    {
        public const string GroupName = "AbpVnext";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class ArticleCategory
        {
            public const string Default = GroupName + ".ArticleCategory";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Article
        {
            public const string Default = GroupName + ".Article";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
