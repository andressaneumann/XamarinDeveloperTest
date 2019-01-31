using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DevelopmentTest.Data;
using DevelopmentTest.Droid.Data;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAndroid))]

namespace DevelopmentTest.Droid.Data
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid()
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