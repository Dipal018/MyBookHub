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
    public partial class ProfilePage : ContentPage
    {
        int userid;
        User user;
		App app = (App)Application.Current;
        public ProfilePage()
        {
			Title = "My Profile";
            InitializeComponent();
           
            if (App.Current.Properties.ContainsKey("userId"))
            {
                userid = (int)App.Current.Properties["userId"];
            }
            else
            { userid = 1; }
            Debug.WriteLine("USERID ::::::::::::::::: " + userid);
            DisplayData(userid);
        }
        public void DisplayData(int userid)
        {
            
			user = app.Database.GetUser(userid);
            firstname.Text = user.first_name;
            lastname.Text = user.last_name;
            contactno.Text = user.contact_number.ToString();
            emailaddress.Text = user.email_id;
            username.Text = user.user_name;
            password.Text = user.password;
        }
		async void updateuser(object s, EventArgs args)
        {
			user = app.Database.GetUser(userid);
            user.first_name = firstname.Text;
            user.last_name = lastname.Text;
            user.contact_number =contactno.Text;
            user.email_id = emailaddress.Text;
            user.password = password.Text;
			app.Database.updateProfile(user);
            await DisplayAlert("Message", "Your Profile is updated!!", "OK");
			await Navigation.PopAsync();
        }
        async void cancelaction(object s, EventArgs args)
        {
			await Navigation.PopAsync();
        }
    }
}
