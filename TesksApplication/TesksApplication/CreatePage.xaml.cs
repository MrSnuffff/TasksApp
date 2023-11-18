using System;
using TesksApplication.Classs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesksApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePage : ContentPage
    {
        public static item _item;
        public  CreatePage()
        {
            InitializeComponent();
            
            
            
        }
        private async void MainPageOpen(object sender, EventArgs e) 
        {
            //await Navigation.PushAsync(new MainPage());
            // _item = new item(NameTask.Text,  DatePickerTesk.Date+ TimePickerTesk.Time, TimeTask.Text, CheckBoxTesk.IsChecked);
            if (string.IsNullOrWhiteSpace(NameTask.Text) || string.IsNullOrWhiteSpace(TimeTask.Text))
            {
                await DisplayAlert("Ошыбка", "Не все поля заполнены", "OK");
                return;
            }
            if (NameTask.Text.Length < 2)
            {
                await DisplayAlert("Ошыбка", "Минимальное кол-во символов в имени 2", "OK");
                return;
            }
            if (Convert.ToInt32(TimeTask.Text) > 24)
            {
                await DisplayAlert("Ошыбка", "Максимальное количевство часов блокировки 24", "OK");
                return;
            }

            _item = new item();
            _item._NameTask = NameTask.Text;
            _item._DP_Time_Tesk = DatePickerTesk.Date + TimePickerTesk.Time;
            _item._Time = Convert.ToByte(TimeTask.Text);
            _item._Block = CheckBoxTesk.IsChecked;
            App.Db.SaveItem(_item);
            //await Navigation.PushAsync(new MainPage());
            await Navigation.PopAsync();
            return;

        }

    }
}