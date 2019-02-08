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
    public partial class LoginScreen : ContentPage
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void SignInProcedure(object sender, EventArgs e)
        {
            UserDatabaseController uc = new UserDatabaseController();
            User user = new User(Entry_username.Text, Entry_password.Text);
            User databaseUser = uc.CheckUserExistance(user);

            if (databaseUser != null)
            {
                DisplayAlert("Login", "Successfull", "Ok");
                App.loggedUser = user;
                Application.Current.MainPage = new NavigationPage(new WelcomePage());
            }
            else
            {
                DisplayAlert("Login", "Incorrect", "Ok");
            }
        }
    }
}