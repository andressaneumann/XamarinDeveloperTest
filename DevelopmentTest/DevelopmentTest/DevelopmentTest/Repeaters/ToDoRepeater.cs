using System;
namespace DevelopmentTest.Repeaters
{
    public class ToDoRepeater
    {

        public string Title { get; set; }
        public string BackgroundColor { get; set; }
        public DateTime Date { get; set; }

        public ToDoRepeater()
        {

        }

        public ToDoRepeater(string title, string color, DateTime date)
        {
            Title = title;
            BackgroundColor = color;
            Date = date;
        }
    }
}
