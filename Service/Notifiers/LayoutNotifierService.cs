using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Notifiers
{
    public class LayoutNotifierService
    {
        public event Action? OnChanged;

        public event Func<Guid, Task?>? OnAdminNotificationReceived;

        public event Func<Guid, Task?>? OnUserNotificationReceived;

        public event Func<Guid, Task?>? OnAllNotificationReceived;

        public void NotifyLayoutChanged()
        {
            if (OnChanged is not null)
                OnChanged?.Invoke();
        }

        public void AdminNotificationReceived(Guid id)
        {
            if (OnAdminNotificationReceived is not null)
                OnAdminNotificationReceived?.Invoke(id);
        }

        public void UserNotificationReceived(Guid id)
        {
            if (OnUserNotificationReceived is not null)
                OnUserNotificationReceived?.Invoke(id);
        }

        public void AllNotificationReceived(Guid id)
        {
            if (OnAllNotificationReceived is not null)
                OnAllNotificationReceived?.Invoke(id);
        }

    }
}
