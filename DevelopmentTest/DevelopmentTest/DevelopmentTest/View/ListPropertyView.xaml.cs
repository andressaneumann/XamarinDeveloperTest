using System;
using System.Collections.Generic;
using DevelopmentTest.Data;
using DevelopmentTest.Models;
using Xamarin.Forms;
using DevelopmentTest.Converters;

namespace DevelopmentTest.View
{
    public partial class ListPropertyView : ContentPage
    {
        public ListPropertyView()
        {
            InitializeComponent();
        }

        public ListPropertyView(ToDoList currentList)
        {
            InitializeComponent();
            this.BindingContext = currentList;
            ToDoDatabaseController td = new ToDoDatabaseController();

            toDoslistView.ItemsSource = td.GetToDo((ToDoList)this.BindingContext);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddToDo((ToDoList)this.BindingContext));
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

        }


    }
}
