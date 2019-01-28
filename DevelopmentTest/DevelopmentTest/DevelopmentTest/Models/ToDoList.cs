using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTest.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<ToDo> ToDos { get; set; }
        public int UserId { get; set; }
    }
}
