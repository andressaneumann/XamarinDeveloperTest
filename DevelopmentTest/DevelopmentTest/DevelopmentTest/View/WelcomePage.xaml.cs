using DevelopmentTest.Data;
using DevelopmentTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevelopmentTest.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
        public WelcomePage()
        {
            InitializeComponent();

            UserDatabaseController uc = new UserDatabaseController();
            ToDoListDatabaseController tc = new ToDoListDatabaseController();

            List<ToDoList> lists = tc.GetToDoLists(App.loggedUser);

            listView.ItemsSource = lists;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddList());
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var viewCell = (ListView)sender;
            ToDoList toDoList = (ToDoList)viewCell.SelectedItem;
            Navigation.PushAsync(new ListPropertyView(toDoList));
        }
    }
}