using Volo.Abp.Settings;

namespace Wzh.AbpVnext.Settings
{
    public class AbpVnextSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpVnextSettings.MySetting1));
        }
    }
}
