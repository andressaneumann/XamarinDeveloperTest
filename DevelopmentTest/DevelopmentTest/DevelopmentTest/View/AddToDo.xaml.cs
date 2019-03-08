﻿using System;
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

            if (td.CreateToDo(ToDoTitle.Text, addedList.Id, datePicker.Date, Picker.PickerSelectedColor)) 
            {
                DisplayAlert("Add ToDo", "ToDo added", "Ok");
                ToDoRepeater rep = new ToDoRepeater() { BackgroundColor = Picker.PickerSelectedColor, Date = datePicker.Date, Title = ToDoTitle.Text };
                ((ToDoViewModel)this.BindingContext).ToDos.Add(rep);
                Navigation.PopAsync();
                //Navigation.RemovePage(this);
                //Navigation.PushAsync(new ListPropertyView((ToDoViewModel)this.BindingContext));

            }
            else
                DisplayAlert("Add ToDo", "Error", "Ok");

        }
    }
}
