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
            User user = new User(Entry_username.Text, Entry_password.Text);

            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login Success", "Oke");
            }
            else
            {
                DisplayAlert("Login", "Incorrect", "Oke");
            }
        }
    }
}