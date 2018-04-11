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
        App app = (App)Application.Current;

        public LoginPage()
        {
			Title = "BookHub";
            InitializeComponent();
			Debug.WriteLine("Open Page ");
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
			{
				await Navigation.PushAsync(new SignUpPage());
				Debug.WriteLine("In Sign up Page");
			};
            lblSignUp.GestureRecognizers.Add(tapGestureRecognizer);
        }
		async void loginuser(object s, EventArgs args)
        {
            if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(password.Text))
            {
                await DisplayAlert("Validation Error", "Username and Password are required", "Re-try");
            }
            else
            {
                // REMEMBER LOGIN STATUS!
                User u = app.Database.Authenticate(username.Text, password.Text);
               // Debug.WriteLine("USER-NAME ::::: "+u.user_name);
               // if (!string.IsNullOrEmpty(u.user_name))
               if(u!=null)
                {
					app.User = u;
                    App.Current.Properties["IsLoggedIn"] = true;
                    App.Current.Properties["userId"] = u.user_id;
					App.Current.Properties["userType"] = u.user_type;
                    if (u.user_type.Equals("Owner"))
                    {
						await Navigation.PushAsync(new HomePage());
						username.Text = "";
						password.Text = "";
                    }
                    else
                    {
						await Navigation.PushAsync(new UserHomePage());
						username.Text = "";
						password.Text = "";
                    }
                }
                else
                {
                    await DisplayAlert("", "InCorrect Username and password!!","OK");
                }
            }           
        }

    }
}
