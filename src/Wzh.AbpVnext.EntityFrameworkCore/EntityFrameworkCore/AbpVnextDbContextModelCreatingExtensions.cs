using Wzh.AbpVnext.Articles;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Wzh.AbpVnext.EntityFrameworkCore
{
    public static class AbpVnextDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpVnext(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpVnextConsts.DbTablePrefix + "YourEntities", AbpVnextConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});


            builder.Entity<ArticleCategory>(b =>
            {
                b.ToTable(AbpVnextConsts.DbTablePrefix + "ArticleCategories", AbpVnextConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });


            builder.Entity<Article>(b =>
            {
                b.ToTable(AbpVnextConsts.DbTablePrefix + "Articles", AbpVnextConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });
        }
    }
}
