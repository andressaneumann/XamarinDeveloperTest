using System;
namespace DevelopmentTest.Repeaters
{
    public class ToDoListRepeater
    {

        public string Title { get; set; }

        public ToDoListRepeater()
        {

        }

        public ToDoListRepeater(string title)
        {
            Title = title;
        }
    }
}
