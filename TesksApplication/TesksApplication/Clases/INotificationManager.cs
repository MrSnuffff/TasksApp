using System;
using System.Collections.Generic;
using System.Text;

namespace TesksApplication.Clases
{
    public interface INotificationManager
    {
        //void start();
        event EventHandler NotificationReceived;
        void Initialize();
        void SendNotification(string title, string message, DateTime? notifyTime = null);
        void ReceiveNotification(string title, string message);
    }
}
