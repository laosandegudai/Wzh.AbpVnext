using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;
using Wzh.AbpVnext.Localization;

namespace Wzh.AbpVnext.Features
{
    public class AbpVnextFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var group = context.AddGroup(AbpVnextFeatures.GroupName);

            group.AddFeature(AbpVnextFeatures.SocialLogins, "true", L("Feature:SocialLogins")
                , valueType: new ToggleStringValueType());
            group.AddFeature(AbpVnextFeatures.UserCount, "10", L("Feature:UserCount")
                , valueType: new FreeTextStringValueType(new NumericValueValidator(1, 1000)));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpVnextResource>(name);
        }
    }
}
