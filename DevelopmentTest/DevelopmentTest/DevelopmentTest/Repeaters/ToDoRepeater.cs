﻿using System;
namespace DevelopmentTest.Repeaters
{
    public class ToDoRepeater
    {

        public string Title { get; set; }
        public string BackgroundColor { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int ListId { get; set; }
        public bool IsChecked { get; set; }

        public ToDoRepeater()
        {

        }

        public ToDoRepeater(string title, string color, DateTime date, int id, int listId)
        {
            Title = title;
            BackgroundColor = color;
            Date = date;
            Id = id;
            ListId = listId;
        }
    }
}
