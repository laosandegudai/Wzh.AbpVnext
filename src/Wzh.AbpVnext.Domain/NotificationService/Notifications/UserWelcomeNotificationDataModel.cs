using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wzh.AbpVnext.NotificationService.Notifications
{
    public class UserWelcomeNotificationDataModel
    {
        public string UserName { get; protected set; }

        public string GiftCardCode { get; protected set; }

        public UserWelcomeNotificationDataModel(
            [NotNull] string userName,
            [NotNull] string giftCardCode)
        {
            UserName = userName;
            GiftCardCode = giftCardCode;
        }
    }
}
