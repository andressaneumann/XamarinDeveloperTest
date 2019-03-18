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

            List<ToDo> toDos = td.GetNotCheckedToDos(((ToDoViewModel)this.BindingContext).SelectedList);

            ((ToDoViewModel)this.BindingContext).ToDos = new ObservableCollection<ToDoRepeater>();
            foreach (ToDo item in toDos)
            {

                ToDoRepeater row = new ToDoRepeater(item.Title, item.ToDoListColor, item.Date, item.Id, item.ToDoListID);
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
            ToDo currentToDo = new ToDo() { Id = currentToDoRepeater.Id, Title = currentToDoRepeater.Title, Date = currentToDoRepeater.Date, 
                ToDoListColor = currentToDoRepeater.BackgroundColor, ToDoListID = currentToDoRepeater.ListId };
            ((ToDoViewModel)this.BindingContext).SelectedToDo = currentToDo;
            Navigation.PushAsync(new ToDoPropertyView((ToDoViewModel)this.BindingContext));
        }

        private void CheckBox_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                
                ToDoDatabaseController td = new ToDoDatabaseController();
                bool answer = await DisplayAlert("Task finished", "Have you finish the task?", "Yes", "No");

                var viewCell = (ContentView)sender;
                ToDoRepeater currentToDoRepeater = (ToDoRepeater)viewCell.BindingContext;
                ToDo currentToDo = new ToDo()
                {
                    Id = currentToDoRepeater.Id,
                    Title = currentToDoRepeater.Title,
                    Date = currentToDoRepeater.Date,
                    ToDoListColor = currentToDoRepeater.BackgroundColor,
                    ToDoListID = currentToDoRepeater.ListId,
                    IsChecked = currentToDoRepeater.IsChecked
                };

                if (answer) {
                    currentToDo.IsChecked = true;
                    Navigation.RemovePage(this);
                    await Navigation.PushAsync(new ListPropertyView((ToDoViewModel)this.BindingContext));
                }
            });
        }
    }
}
