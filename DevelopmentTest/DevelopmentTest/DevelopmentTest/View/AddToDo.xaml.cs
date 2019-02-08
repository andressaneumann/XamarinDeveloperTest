using System;
using System.Collections.Generic;
using DevelopmentTest.Data;
using DevelopmentTest.Models;
using Xamarin.Forms;

namespace DevelopmentTest.View
{
    public partial class AddToDo : ContentPage
    {
        public AddToDo()
        {
            InitializeComponent();
        }

        public AddToDo(ToDoList currentList)
        {
            InitializeComponent();
            this.BindingContext = currentList;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var viewCell = (Button)sender;
            ToDoDatabaseController td = new ToDoDatabaseController();
            if (td.CreateToDo(ToDoTitle.Text, ((ToDoList)this.BindingContext).Id)) 
            {
                DisplayAlert("Add ToDo", "ToDo added", "Ok");
                Navigation.PushAsync(new ListPropertyView((ToDoList)this.BindingContext));
            }
            else
                DisplayAlert("Add ToDo", "Error", "Ok");

        }
    }
}
