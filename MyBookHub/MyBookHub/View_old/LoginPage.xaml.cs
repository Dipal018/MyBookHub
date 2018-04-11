using MyBookHub.Data;
using MyBookHub.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyBookHub.View
{
    public partial class LoginPage : ContentPage
    {
        User user;
        UserDB _userdb;
        public LoginPage()
        {
            InitializeComponent();
            this.BackgroundColor = Color.FromHex("#FDF2E9");
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                //  Device.OpenUri(new Uri(((Label)s).Text));
                Navigation.PushModalAsync(new SignUpPage());
            };
            lblSignUp.GestureRecognizers.Add(tapGestureRecognizer);
        }
        public void loginuser(object s, EventArgs args)
        {
            if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(password.Text))
            {
                DisplayAlert("Validation Error", "Username and Password are required", "Re-try");
            }
            else
            {
                // REMEMBER LOGIN STATUS!
                
                user = new User();
                _userdb = new UserDB();
                User u = _userdb.Authenticate(username.Text, password.Text);
               // Debug.WriteLine("USER-NAME ::::: "+u.user_name);
               // if (!string.IsNullOrEmpty(u.user_name))
               if(u!=null)
                {
                    App.Current.Properties["IsLoggedIn"] = true;
                    App.Current.Properties["userId"] = u.user_id;
                    if (u.user_type.Equals("Owner"))
                    {
                        Navigation.PushModalAsync(new HomePage());
                    }
                    else
                    {
                        Navigation.PushModalAsync(new UserHomePage());
                    }
                }
                else
                {
                    DisplayAlert("", "InCorrect Username and password!!","OK");
                }
            }           
        }

    }
}
