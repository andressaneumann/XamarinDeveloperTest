using System;
using System.Collections.Generic;
using DevelopmentTest.Data;
using DevelopmentTest.Models;
using Xamarin.Forms;
using DevelopmentTest.Converters;
using System.Collections.ObjectModel;
using DevelopmentTest.Repeaters;
using System.Threading.Tasks;

namespace DevelopmentTest.View
{
    public partial class ListPropertyView : ContentPage
    {

        private ObservableCollection<ToDoRepeater> items = new ObservableCollection<ToDoRepeater>();
        private ToDoRepeater toDo = new ToDoRepeater();

        public ListPropertyView()
        {
            InitializeComponent();
        }

        public ListPropertyView(ToDoList currentList)
        {
            InitializeComponent();
            this.BindingContext = currentList;
            ToDoDatabaseController td = new ToDoDatabaseController();

            List<ToDo> toDos = td.GetToDo((ToDoList)this.BindingContext);

            foreach (ToDo item in toDos)
            {

                ToDoRepeater row = new ToDoRepeater(item.Title, item.ToDoListColor, item.Date);
                items.Add(row);

            }

            MainRepeater.ItemsSource = items;
        }

        void AddToDo(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddToDo((ToDoList)this.BindingContext));
        }


        void DeleteList(object sender, System.EventArgs e)
        {

            ToDoListDatabaseController td = new ToDoListDatabaseController();
            Device.BeginInvokeOnMainThread(async () =>
            {
                bool answer = await DisplayAlert("Delete list", "Are you sure?", "Yes", "No");

                if (answer)
                {
                    if (td.DeleteList((ToDoList)this.BindingContext))
                    {
                        await Navigation.PopAsync();
                    }
                }
            });
        }

    }
}
