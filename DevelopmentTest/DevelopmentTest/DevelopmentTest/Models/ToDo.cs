using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevelopmentTest.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int ToDoListID { get; set; }
        public string ToDoListColor { get; set; }
        public DateTime Date { get; set; }

    }
}
