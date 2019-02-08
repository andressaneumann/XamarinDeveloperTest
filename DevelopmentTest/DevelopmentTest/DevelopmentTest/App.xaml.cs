using DevelopmentTest.Data;
using DevelopmentTest.Models;
using DevelopmentTest.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DevelopmentTest
{
    public partial class App : Application
    {

        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;

        public static User loggedUser { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new LoginScreen();

            loggedUser = null;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase == null)
                    userDatabase = new UserDatabaseController();

                return userDatabase;
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                    tokenDatabase = new TokenDatabaseController();

                return tokenDatabase;
            }
        }
    }
}
