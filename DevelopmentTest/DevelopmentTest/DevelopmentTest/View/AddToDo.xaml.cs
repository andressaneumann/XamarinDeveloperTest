using System;
using System.Collections.Generic;
using DevelopmentTest.Data;
using DevelopmentTest.Models;
using DevelopmentTest.ViewModel;
using DevelopmentTest.Repeaters;
using Xamarin.Forms;

namespace DevelopmentTest.View
{
    public partial class AddToDo : ContentPage
    {
        public AddToDo()
        {
            InitializeComponent();
        }

        public AddToDo(ToDoViewModel currentList)
        {
            InitializeComponent();
            this.BindingContext = currentList;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var viewCell = (Button)sender;
            ToDoDatabaseController td = new ToDoDatabaseController();

            ToDoList addedList = ((ToDoViewModel)this.BindingContext).SelectedList;

            int toDoId = td.CreateToDo(ToDoTitle.Text, addedList.Id, datePicker.Date, Picker.PickerSelectedColor);

            if (toDoId != 0) 
            {
                DisplayAlert("Add ToDo", "ToDo added", "Ok");
                ToDoRepeater rep = new ToDoRepeater() { BackgroundColor = Picker.PickerSelectedColor, Date = datePicker.Date, Title = ToDoTitle.Text, Id = toDoId };
                ((ToDoViewModel)this.BindingContext).ToDos.Add(rep);
                Navigation.PopAsync();

            }
            else
                DisplayAlert("Add ToDo", "Error", "Ok");

        }
    }
}
