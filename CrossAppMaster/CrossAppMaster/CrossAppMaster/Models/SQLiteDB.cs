using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using SQLite;

namespace CrossAppMaster.Models
{
    public class SQLiteDB : IDisposable
    {
        private SQLiteAsyncConnection connection { get; set; }
        public SQLiteDB()
        {
            string dbname = "CrossAppMaster_Yugioh_Api.db3";
            string sqlitepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),dbname);
            try 
            {
                this.connection = new SQLiteAsyncConnection(sqlitepath);
                connection.CreateTableAsync<SavedCards>();
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
        }

        public void Dispose()
        {
            connection.CloseAsync();
        }
    }
}
