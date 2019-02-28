using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTest.Models
{
    public class ToDoList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }

        [Ignore]
        public List<ToDo> ToDos { get; set; }
        public int UserId { get; set; }
        public string ListColor { get; set; }
        public DateTime Date { get; set; }

    }
}
