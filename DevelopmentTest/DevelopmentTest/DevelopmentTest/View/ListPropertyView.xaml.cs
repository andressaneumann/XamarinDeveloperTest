using System;
using System.Collections.Generic;
using DevelopmentTest.Data;
using DevelopmentTest.Models;
using Xamarin.Forms;
using DevelopmentTest.Converters;
using System.Collections.ObjectModel;
using DevelopmentTest.Repeaters;
using System.Threading.Tasks;
using DevelopmentTest.ViewModel;

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

        public ListPropertyView(ToDoViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
            ToDoDatabaseController td = new ToDoDatabaseController();

            List<ToDo> toDos = td.GetToDo(((ToDoViewModel)this.BindingContext).SelectedList);

            ((ToDoViewModel)this.BindingContext).ToDos = new ObservableCollection<ToDoRepeater>();
            foreach (ToDo item in toDos)
            {

                ToDoRepeater row = new ToDoRepeater(item.Title, item.ToDoListColor, item.Date, item.Id);
                ((ToDoViewModel)this.BindingContext).ToDos.Add(row);
            }
        }

        void AddToDo(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddToDo((ToDoViewModel)this.BindingContext));
        }


        void DeleteList(object sender, System.EventArgs e)
        {

            ToDoListDatabaseController td = new ToDoListDatabaseController();
            Device.BeginInvokeOnMainThread(async () =>
            {
                bool answer = await DisplayAlert("Delete list", "Are you sure?", "Yes", "No");

                if (answer)
                {
                    if (td.DeleteList(((ToDoViewModel)this.BindingContext).SelectedList))
                    {
                        ((ToDoViewModel)this.BindingContext).ToDoList.Remove(((ToDoViewModel)this.BindingContext).SelectedList);
                        await Navigation.PopAsync();
                    }
                }
            });
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var viewCell = (ContentView)sender;
            ToDoRepeater currentToDoRepeater = (ToDoRepeater)viewCell.BindingContext;
            ToDo currentToDo = new ToDo() { Id = currentToDoRepeater.Id, Title = currentToDoRepeater.Title, Date = currentToDoRepeater.Date, ToDoListColor = currentToDoRepeater.BackgroundColor };
            ((ToDoViewModel)this.BindingContext).SelectedToDo = currentToDo;
            Navigation.PushAsync(new ToDoPropertyView((ToDoViewModel)this.BindingContext));
        }
    }
}
