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

        public List<ToDoList> GetToDoLists(User user)
        {
            lock (locker)
            {
                string query = $"SELECT * FROM ToDoList WHERE UserId = '{user.Id}' ";
                List<ToDoList> databaseToDoList = database.Query<ToDoList>(query).ToList();

                if (databaseToDoList != null)
                    return databaseToDoList;

                return null;
            }
        }
        public List<ToDoList> GetToDo(ToDoList list)
        {
            lock (locker)
            {
                string query = $"SELECT * FROM ToDoList WHERE Title =  '{list.Title}'";
                List<ToDoList> databaseToDoList = database.Query<ToDoList>(query).ToList();

                if (databaseToDoList != null)
                    return databaseToDoList;

                return null;
            }
        }

        public bool CreateToDoList(string title)
        {
            lock (locker)
            {
                if(title != "")
                {
                    ToDoList list = new ToDoList() { Title = title };
                    database.Insert(list);
                    return true;
                }

                return false;
            }
        }

        //public bool UpdateTable(ToDoList todoList)
        //{
        //    lock (locker)
        //    {

        //    }
        //}

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
