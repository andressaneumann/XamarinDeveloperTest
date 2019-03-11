using System;
using System.Collections.Generic;
using System.Linq;
using DevelopmentTest.Models;
using SQLite;
using Xamarin.Forms;

namespace DevelopmentTest.Data
{
    public class ToDoDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public ToDoDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<ToDo>();
        }

        public List<ToDo> GetToDo(ToDoList list)
        {
            lock (locker)
            {
                string query = $"SELECT * FROM ToDo WHERE ToDoListID = '{list.Id}' ";
                List<ToDo> databaseToDo = database.Query<ToDo>(query).ToList();

                if (databaseToDo != null)
                    return databaseToDo;

                return null;
            }
        }

        public bool CheckToDoExistence(int toDoId)
        {
            lock (locker)
            {
                string query = $"SELECT * FROM ToDoList WHERE Id = '{toDoId}' ";
                ToDo databaseToDo = (ToDo)database.Query<ToDo>(query).FirstOrDefault();

                if (databaseToDo != null)
                    return true;

                return false;
            }
        }

        public bool CreateToDo(string title, int listId, DateTime date, string color)
        {
            lock (locker)
            {
                if (title != "")
                {
                    ToDo toDo = new ToDo() { Title = title, ToDoListID = listId, Date = date, ToDoListColor = color };
                    database.Insert(toDo);
                    return true;
                }

                return false;
            }
        }

        public bool UpdateToDo(string title, int id, DateTime date, string color)
        {
            lock (locker)
            {
                if (CheckToDoExistence(id))
                {

                    ToDo toDo = new ToDo() { Title = title, Date = date, ToDoListColor = color };
                    database.Update(toDo);
                    return true;
                }

                return false;
            }
        }

        public bool DeleteToDo(ToDo toDo)
        {
            lock (locker)
            {
                string query = $"SELECT Id FROM ToDo WHERE Id = '{toDo.Id}'";
                ToDo databaseToDo = (ToDo)database.Query<ToDo>(query).FirstOrDefault();


                if (databaseToDo != null)
                {
                    database.Delete<ToDo>(databaseToDo);
                    return true;
                }

                return false;
            }
        }

    }
}
