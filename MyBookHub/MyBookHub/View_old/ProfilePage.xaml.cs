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
        UserDB _userdb;
        public ProfilePage()
        {
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
            _userdb = new UserDB();
            user = _userdb.GetUser(userid);
            firstname.Text = user.first_name;
            lastname.Text = user.last_name;
            contactno.Text = user.contact_number.ToString();
            emailaddress.Text = user.email_id;
            username.Text = user.user_name;
            password.Text = user.password;
        }
        public void updateuser(object s, EventArgs args)
        {
            user = _userdb.GetUser(userid);
            user.first_name = firstname.Text;
            user.last_name = lastname.Text;
            user.contact_number =contactno.Text;
            user.email_id = emailaddress.Text;
            user.password = password.Text;
            int result = _userdb.updateProfile(user);
            DisplayAlert("Message", "Your Profile is updated!!", "OK");
            Navigation.PushModalAsync(new HomePage());
        }
        public void cancelaction(object s, EventArgs args)
        {
            DisplayData(userid);
        }
    }
}
