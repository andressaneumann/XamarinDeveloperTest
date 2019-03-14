﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevelopmentTest.Data;
using DevelopmentTest.Models;
using DevelopmentTest.Repeaters;
using DevelopmentTest.ViewModel;
using DevelopmentTest.Converters;
using Xamarin.Forms;

namespace DevelopmentTest.View
{
    public partial class ToDoPropertyView : ContentPage
    {
        public ToDoPropertyView(ToDoViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }

        void Update_ToDo(object sender, System.EventArgs e)
        {
            var viewCell = (Button)sender;
            ToDo currentToDo = ((ToDoViewModel)viewCell.BindingContext).SelectedToDo;
            ToDoDatabaseController td = new ToDoDatabaseController();

            if (td.UpdateToDo(currentToDo))
            {
                DisplayAlert("Update ToDo", "ToDo updated", "Ok");
                List<ToDo> toDos = td.GetToDo(((ToDoViewModel)this.BindingContext).SelectedList);

                var converter = new DateFormatConverter();


                ((ToDoViewModel)this.BindingContext).ToDos = new ObservableCollection<ToDoRepeater>();
                foreach (ToDo item in toDos)
                {
                    ToDoRepeater row = new ToDoRepeater(item.Title, item.ToDoListColor, item.Date, item.Id, item.ToDoListID);
                    ((ToDoViewModel)this.BindingContext).ToDos.Add(row);
                }

                Navigation.PopAsync();
            }
            else
                DisplayAlert("Update ToDo", "Error", "Ok");

        }
    }
}
