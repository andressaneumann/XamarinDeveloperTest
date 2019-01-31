using DevelopmentTest.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTest.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {

        }

        public User (string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public bool CheckInformation()
        {

            UserDatabaseController user = new UserDatabaseController();


            if (user.CheckUserExistance(this))
                return true;

            return false;
        }
    }
}
