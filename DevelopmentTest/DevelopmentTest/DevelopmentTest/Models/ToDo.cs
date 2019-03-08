using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using SQLite;

namespace DevelopmentTest.Models
{
    public class ToDo 
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public string Title { get; set; }

        public int ToDoListID { get; set; }
        public string ToDoListColor { get; set; }
        public DateTime Date { get; set; }


    }
}
