using EasyAbp.NotificationService.Notifications;
using EasyAbp.NotificationService.Provider.Mailing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.TextTemplating;

namespace Wzh.AbpVnext.NotificationService.Notifications.Mailing
{
    public class UserWelcomeNotificationFactory : NotificationFactory<UserWelcomeNotificationDataModel, CreateEmailNotificationEto>, ITransientDependency
    {
        private readonly ITemplateRenderer _templateRenderer;

        public UserWelcomeNotificationFactory(ITemplateRenderer templateRenderer)
        {
            _templateRenderer = templateRenderer;
        }

        public override async Task<CreateEmailNotificationEto> CreateAsync(UserWelcomeNotificationDataModel model, IEnumerable<Guid> userIds)
        {
            var subject = await _templateRenderer.RenderAsync("UserWelcomeEmailSubject", model);

            var body = await _templateRenderer.RenderAsync("UserWelcomeEmailBody", model);

            return new CreateEmailNotificationEto(userIds, subject, body);
        }
    }
}
