using System;
namespace DevelopmentTest.Repeaters
{
    public class ToDoRepeater
    {

        public string Title { get; set; }
        public string Color { get; set; }
        public DateTime Date { get; set; }


        public ToDoRepeater()
        {

        }

        public ToDoRepeater(string title, string color, DateTime date)
        {
            Title = title;
            Color = color;
            Date = date;
        }
    }
}
