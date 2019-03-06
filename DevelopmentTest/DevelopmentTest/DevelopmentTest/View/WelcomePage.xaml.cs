using DevelopmentTest.Data;
using DevelopmentTest.Models;
using DevelopmentTest.ViewModel;
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


        private List<ToDoList> results;

        public WelcomePage()
        {
            InitializeComponent();
            this.BindingContext = new ToDoViewModel();
        }

        ToDoListDatabaseController tc = new ToDoListDatabaseController();

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddList());
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var viewCell = (ListView)sender;
            ToDoList toDoList = (ToDoList)viewCell.SelectedItem;
            ((ToDoViewModel)this.BindingContext).selectedList = toDoList;
            Navigation.PushAsync(new ListPropertyView((ToDoViewModel)this.BindingContext));
        }

        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }


        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            listView.ItemsSource = from x in results where x.Title.Contains(e.NewTextValue) select x;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    UserDatabaseController uc = new UserDatabaseController();
        //    ToDoListDatabaseController tc = new ToDoListDatabaseController();

        //    this.results = tc.GetToDoLists(App.loggedUser);

        //    listView.ItemsSource = results;
        //}
    }
}