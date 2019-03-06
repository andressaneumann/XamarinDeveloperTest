using System;
using System.ComponentModel;
using System.Collections.Generic;
using DevelopmentTest.Models;
using DevelopmentTest.Data;
using DevelopmentTest.Repeaters;

namespace DevelopmentTest.ViewModel
{
    public class ToDoViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChangef implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        ToDoListDatabaseController toDoListController { get; set; }
        public ToDoListDatabaseController ToDoListController => toDoListController;

        public ToDoViewModel()
        {
            toDoListController = new ToDoListDatabaseController();
            toDoList = toDoListController.GetToDoLists(App.loggedUser);
            toDos = new List<ToDoRepeater>();
        }

        List<ToDoList> toDoList;
        public List<ToDoList> ToDoList
        {

            get { return toDoList; }

            set
            {
                toDoList = value;
                this.Notify("ToDoList");
            }
        }



        ToDoList selectedList;
        public ToDoList SelectedList
        {

            get { return selectedList; }

            set
            {
                selectedList = value;
                this.Notify("SelectedList");
            }
        }

        List<ToDoRepeater> toDos;
        public List<ToDoRepeater> ToDos
        {

            get { return toDos; }

            set
            {
                toDos = value;
                this.Notify("ToDos");
            }
        }

    }

}
