using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TesksApplication.Classs
{
    public class DB
    {
        private readonly SQLiteConnection conn;
        public DB(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<item>();
        }

        public List<item> GetItems() 
        {
            return conn.Table<item>().ToList();
        }

        public int SaveItem( item _item)
        {
            return conn.Insert(_item);
        }
        public int DeleteItemById(int itemId)
        {
            return conn.Delete<item>(itemId);
        }
    }
}
