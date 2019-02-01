using DevelopmentTest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DevelopmentTest.Data
{
    public class ToDoListDatabaseController
    {

        static object locker = new object();

        SQLiteConnection database;

        public ToDoListDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<ToDoList>();

            ToDoList firstList = new ToDoList
            {
                Id = 1,
                Title = "Home",
                UserId = 1
            };

            database.Insert(firstList);

        }


        public bool CheckToDoListExistence(ToDoList toDoList)
        {
            lock (locker)
            {
                string query = $"SELECT * FROM ToDoList WHERE Id = '{toDoList.Id}' ";
                ToDoList databaseToDoList = (ToDoList)database.Query<ToDoList>(query).FirstOrDefault();

                if (databaseToDoList != null)
                    return true;

                return false;
            }
        }

        public bool GetToDoList(User user)
        {

        }

        public bool CreateToDoList(ToDoList toDoList)
        {
            lock (locker)
            {
                if(toDoList != null)
                {
                    database.Insert(toDoList);
                    return true;
                }

                return false;
            }
        }

        public bool UpdateTable(ToDoList todoList)
        {
            lock (locker)
            {

            }
        }

        public bool DeleteList(ToDoList toDoList)
        {
            lock (locker)
            {
                string query = $"SELECT Id FROM ToDoList WHERE Id = '{toDoList.Id}'";
                ToDoList databaseToDoList = (ToDoList)database.Query<ToDoList>(query).FirstOrDefault();


                if (databaseToDoList != null)
                {
                    database.Delete<ToDoList>(databaseToDoList);
                    return true;
                }

                return false;
            }
        }
   
    }
}
