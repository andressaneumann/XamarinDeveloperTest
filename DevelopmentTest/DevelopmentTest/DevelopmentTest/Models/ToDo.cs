using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;

namespace DevelopmentTest.Models
{
    public class ToDo : INotifyPropertyChanged
    {
    
        int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {

            get { return id; }

            set
            {
                id = value;
                OnPropertyChanged();
            }

        }

        string title;
        public string Title
        {

            get { return title; }

            set
            {

                title = value;
                OnPropertyChanged();

            }
        }

        int toDoList;
        public int ToDoListID
        {

            get { return toDoList; }

            set
            {

                toDoList = value;
                OnPropertyChanged();

            }
        }

        string toDoListColor;
        public string ToDoListColor
        {

            get { return toDoListColor; }

            set
            {

                toDoListColor = value;
                OnPropertyChanged();

            }
        }

        DateTime date;
        public DateTime Date
        {

            get { return date; }

            set
            {

                date = value;
                OnPropertyChanged();

            }
        }

        bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }

            set
            {
                isChecked = value;
                OnPropertyChanged();
            }
        } 


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
