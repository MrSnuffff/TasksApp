using Android.App;
using Android.Content;
using Android.OS;
using TesksApplication.Clases;
using TesksApplication.Classs;
namespace TesksApplication.Droid
{
    [BroadcastReceiver]
    public class BackgroundReceiver : BroadcastReceiver
    {
        INotificationManager notificationManager;

        public override void OnReceive(Context context, Intent intent)
        {

            PowerManager pm = (PowerManager)context.GetSystemService(Context.PowerService);
            PowerManager.WakeLock wakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "BackgroundReceiver");
            wakeLock.Acquire();

            // Run your code here
            item item = App.Check();
            if (item == null)
                return;
            else
            {
                string title = "Time to get things done";
                string message = item._NameTask;
                notificationManager.SendNotification(title, message);
            }

            wakeLock.Release();
        }
    }
}