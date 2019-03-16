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
                string query = $"SELECT * FROM ToDo WHERE Id = '{toDoId}' ";
                ToDo databaseToDo = (ToDo)database.Query<ToDo>(query).FirstOrDefault();

                if (databaseToDo != null)
                    return true;

                return false;
            }
        }

        public int CreateToDo(string title, int listId, DateTime date, string color)
        {
            lock (locker)
            {
                if (title != "")
                {
                    ToDo toDo = new ToDo() { Title = title,  ToDoListID = listId, Date = date, ToDoListColor = color };
                    database.Insert(toDo);
                    return GetLastInsertId();
                }

                return 0;
            }
        }

        public int GetLastInsertId()
        {
            return (int)SQLite3.LastInsertRowid(database.Handle);
        }


        public int CreateId()
        {
            var table = database.Table<ToDo>();
            long prodID = table.Max(x => x.Id);

            return (int)prodID+1;

        }

        public bool UpdateToDo(ToDo toDo)
        {
            lock (locker)
            {
                if (CheckToDoExistence(toDo.Id))
                {
                    var count = database.Query<ToDo>($"UPDATE [ToDo] SET Title = '{toDo.Title}', ToDoListColor = '{toDo.ToDoListColor}', Date = '{toDo.Date}' Where Id = {toDo.Id}");
                    return true; 
                }

                return false;
            }
        }

        public bool DeleteToDo(ToDo toDo)
        {
            lock (locker)
            {
                string query = $"SELECT * FROM ToDo WHERE Id = '{toDo.Id}'";
                ToDo databaseToDo = (ToDo)database.Query<ToDo>(query).FirstOrDefault();


                if (databaseToDo != null)
                {
                    try
                    {
                        database.Delete<ToDo>(databaseToDo.Id);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    
                    return true;
                }

                return false;
            }
        }

    }
}
