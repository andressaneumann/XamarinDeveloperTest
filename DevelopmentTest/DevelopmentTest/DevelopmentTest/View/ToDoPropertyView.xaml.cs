using System;
using System.Collections.Generic;
using DevelopmentTest.Data;
using DevelopmentTest.ViewModel;
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
            var viewCell = (ContentView)sender;
            ToDoDatabaseController td = new ToDoDatabaseController();

            if (td.UpdateToDo(ToDoTitle.Text, , datePicker.Date, Picker.PickerSelectedColor))
            {

            }
        }
    }
}
