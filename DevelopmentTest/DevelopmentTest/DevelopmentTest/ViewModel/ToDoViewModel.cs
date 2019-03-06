using System;
using System.ComponentModel;
using System.Collections.Generic;
using DevelopmentTest.Models;
using DevelopmentTest.Data;

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
        }

        public List<ToDoList> toDoList
        {

            get { return toDoList; }

            set
            {
                toDoList = value;
                this.Notify("toDoList");
            }
        }

        public ToDoList selectedList
        {

            get { return selectedList; }

            set
            {
                selectedList = value;
                this.Notify("selectedList");
            }
        }

    }

}
