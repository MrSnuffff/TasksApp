using System;
using System.Threading.Tasks;
using TesksApplication.Clases;
using TesksApplication.Classs;
using Xamarin.Forms;

namespace TesksApplication
{

    public partial class MainPage : ContentPage
    {
        INotificationManager notificationManager;
        

        public MainPage()
        {
            InitializeComponent();
            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };
        }

        public  void ShowNotif(item item)
        {
            string title = "Time to get things done";
            string message = item._NameTask;
            notificationManager.SendNotification(title, message);

        }
        

        void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
                };
                stackLayout.Children.Add(msg);
            });
        }
        protected override void OnAppearing()
        {
            ShowItems();
        }
        public  void ShowItems()
        {
            itemsCollection.ItemsSource = App.Db.GetItems();
        }
        private async void CraetePageOpen(object sender, EventArgs e)
        {
            CreatePage createPage = new CreatePage();
            await Navigation.PushAsync(createPage);
            ShowItems();

        }
        private  async void  OnCheckBoxChecked(object sender, CheckedChangedEventArgs e)
        {

            CheckBox checkBox = (CheckBox)sender;
            
            StackLayout parentStackLayout = (StackLayout)checkBox.Parent;
            Label itemIdLabel = parentStackLayout.FindByName<Label>("ItemIdLabel");

            if (itemIdLabel != null && int.TryParse(itemIdLabel.Text, out int itemId))
            {
                await Task.Delay(500);
                App.Db.DeleteItemById(itemId);
                ShowItems();
            }
        }
    }
}
