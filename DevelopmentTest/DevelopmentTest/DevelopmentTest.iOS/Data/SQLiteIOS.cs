using System;
using System.IO;
using DevelopmentTest.Data;
using DevelopmentTest.iOS.Data;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteIOS))]

namespace DevelopmentTest.iOS.Data
{
    public class SQLiteIOS : ISQLite
    {
        public SQLiteIOS()
        {

        }


        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);

            var conm = new SQLite.SQLiteConnection(path);

            return conm;
        }
    }
}
