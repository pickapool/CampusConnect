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

        public event Func<Guid, Task?>? OnNotificationReceived;

        public void NotifyChanged()
        {
            if (OnChanged is not null)
                OnChanged?.Invoke();
        }

        public void NotificationReceived(Guid id)
        {
            if (OnNotificationReceived is not null)
                OnNotificationReceived?.Invoke(id);
        }

    }
}
