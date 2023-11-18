using System;
using TesksApplication.Classs;
using Xamarin.Forms;
using System.IO;
using System.Collections.Generic;

namespace TesksApplication
{
    public partial class App : Application
    {
        private static DB db;
        public static DB Db
        {
            get
            {
                if (db == null)
                {
                    db = new DB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DB.sqlite"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static item Check()
        {
            DateTime currentDate = DateTime.Now;
            List<item> Items = db.GetItems();
            
            foreach(item item in Items)
            {
                DateTime dt = item._DP_Time_Tesk;
                if (dt >= currentDate) 
                {
                    return item;
                }
            }
            return null;
        }
        
    }
}
