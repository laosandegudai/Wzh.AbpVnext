using EasyAbp.NotificationService.Notifications;
using EasyAbp.NotificationService.Provider.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Wzh.AbpVnext.NotificationService.Notifications.Sms
{
    public class UserWelcomeNotificationFactory : NotificationFactory<UserWelcomeNotificationDataModel, CreateSmsNotificationEto>, ITransientDependency
    {
        public override async Task<CreateSmsNotificationEto> CreateAsync(UserWelcomeNotificationDataModel model, IEnumerable<Guid> userIds)
        {
            var text = $"Hello, {model.UserName}, here is a gift card code for you: {model.GiftCardCode}";

            return new CreateSmsNotificationEto(userIds, text, new Dictionary<string, object>());
        }
    }
}
