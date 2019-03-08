using System;
using System.ComponentModel;
using System.Collections.Generic;
using DevelopmentTest.Models;
using DevelopmentTest.Data;
using DevelopmentTest.Repeaters;
using System.Collections.ObjectModel;

namespace DevelopmentTest.ViewModel
{
    public class ToDoViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChangef implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void Notify(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ToDoListDatabaseController toDoListController { get; set; }
        public ToDoListDatabaseController ToDoListController => toDoListController;

        public ToDoViewModel()
        {
            toDoListController = new ToDoListDatabaseController();
            List<ToDoList> getLists = toDoListController.GetToDoLists(App.loggedUser);
            ObservableCollection<ToDoList> dbLists = new ObservableCollection<ToDoList>();
            getLists.ForEach(x => dbLists.Add(x));
            toDoList = dbLists;
            toDos = new ObservableCollection<ToDoRepeater>();
        }

        ObservableCollection<ToDoList> toDoList;
        public ObservableCollection<ToDoList> ToDoList
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

        ObservableCollection<ToDoRepeater> toDos;
        public ObservableCollection<ToDoRepeater> ToDos
        {
            get { 
                return toDos; 
            }
            set
            {
                toDos = value;
                this.Notify("ToDos");
            }
        }

    }

}
