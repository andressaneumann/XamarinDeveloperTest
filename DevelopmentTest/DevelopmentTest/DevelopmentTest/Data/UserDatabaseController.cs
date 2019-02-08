using DevelopmentTest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DevelopmentTest.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();

            //User admin = new User
            //{
            //    Email = "admin@admin.com",
            //    Username = "admin1",
            //    Id = 1,
            //    Name = "Admin",
            //    Password = "123"
            //};

            //database.Insert(admin);

        }

        public User GetUser()
        {
            lock (locker)
            {
                if(database.Table<User>().Count() == 0)
                {
                    return null;
                } else
                {
                    return database.Table<User>().First();
                }
            }
        }

        public User CheckUserExistance(User user)
        {
            lock (locker)
            {
                string query = $"SELECT * FROM User WHERE Username = '{user.Username}' AND Password = '{user.Password}'";
                User databaseUser = (User)database.Query<User>(query).FirstOrDefault();

                if (databaseUser != null)
                    return databaseUser;

                return null;
            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                if(user.Id != 0)
                {
                    database.Update(user);
                    return user.Id;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
