using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;
using Wzh.AbpVnext.Identity;
using Wzh.AbpVnext.Users;

namespace Wzh.AbpVnext
{
    public static class AbpVnextDtoExtensions
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                /* You can add extension properties to DTOs
                 * defined in the depended modules.
                 *
                 * Example:
                 *
                 * ObjectExtensionManager.Instance
                 *   .AddOrUpdateProperty<IdentityRoleDto, string>("Title");
                 *
                 * See the documentation for more:
                 * https://docs.abp.io/en/abp/latest/Object-Extensions
                 */
                ObjectExtensionManager.Instance
                    .AddOrUpdateProperty<int?>(
                        new[]
                        {
                            typeof(IdentityUserDto),
                            typeof(IdentityUserCreateDto),
                            typeof(IdentityUserUpdateDto),
                            typeof(IdentityUserOrgCreateDto),
                            typeof(IdentityUserOrgUpdateDto),
                        },
                        "Sex" 
                    );
                //ObjectExtensionManager.Instance
                //    .AddOrUpdateProperty<IdentityUserDto, AppUserSex?>(
                //    nameof(AppUser.Sex),
                //    options =>
                //    {
                //        options.CheckPairDefinitionOnMapping = false;
                //    }
                //);
            });
        }
    }
}