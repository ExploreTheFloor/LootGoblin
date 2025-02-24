using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

namespace LootGoblin.Windows
{
    public class ToastManager
    {
        public void LaunchToastNotification(string title, string description)
        {

            new ToastContentBuilder()
                .AddText(title)
                .AddText(description).Show();
        }
    }
}
