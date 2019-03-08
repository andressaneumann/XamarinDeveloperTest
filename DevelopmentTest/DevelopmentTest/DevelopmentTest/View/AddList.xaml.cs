using System;
using System.Collections.Generic;
using DevelopmentTest.Data;
using DevelopmentTest.Models;
using DevelopmentTest.ViewModel;
using Xamarin.Forms;

namespace DevelopmentTest.View
{
    public partial class AddList : ContentPage
    {

        public AddList(ToDoViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            ToDoListDatabaseController tc = new ToDoListDatabaseController();

            if (tc.CreateToDoList(ToDoTitle.Text))
            {
                DisplayAlert("Add list", "List added", "Ok");
                ToDoList newList = new ToDoList() { Title = ToDoTitle.Text }; 
                ((ToDoViewModel)this.BindingContext).ToDoList.Add(newList);
                Navigation.PopAsync();
            }
            else
                DisplayAlert("Add list", "Error", "Ok");
        }
    }
}
