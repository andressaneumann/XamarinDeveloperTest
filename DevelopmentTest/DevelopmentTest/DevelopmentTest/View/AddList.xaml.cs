using System;
using System.Collections.Generic;
using DevelopmentTest.Data;
using Xamarin.Forms;

namespace DevelopmentTest.View
{
    public partial class AddList : ContentPage
    {


        public AddList()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            ToDoListDatabaseController tc = new ToDoListDatabaseController();

            if (tc.CreateToDoList(ToDoTitle.Text))
            {
                DisplayAlert("Add list", "List added", "Ok");
                Application.Current.MainPage = new NavigationPage(new WelcomePage());
            }
            else
                DisplayAlert("Add list", "Error", "Ok");
        }
    }
}
