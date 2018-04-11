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
    public partial class SignUpPage : ContentPage
    {
        public UserDB _userdb;
        public User user;
        int bookOwnerId;
        public SignUpPage()
        {
            InitializeComponent();
            this.BackgroundColor = Color.FromHex("#FDF2E9");
            user = new User();
            _userdb = new UserDB();
           // u = _u.GetUserType("test1");
            //Debug.WriteLine("user_type ::::::::::::::::::::::: "+u.user_type);
        }
        public void adduser(object s, EventArgs args)
        {
           
            user.first_name = firstname.Text;
            user.last_name = lastname.Text;
            user.contact_number =contactno.Text;
            user.email_id = emailaddress.Text;
            user.user_name = username.Text;
            user.user_type = userType.Items[userType.SelectedIndex];
            if (user.user_type.Equals("Borrower"))
            {
                string val = bookOwner.Items[bookOwner.SelectedIndex];
                Debug.WriteLine("BOOK OWNER NAME SELECTED :::::" + val);
               
                string[] name = val.Split(' ');
                User u = _userdb.GetBookOwnerId(name[0], name[1]);
                user.owner_id = u.user_id;
            }

            if (confirmPasswordBehavior.IsValid)
            {
                user.password = password.Text;
                _userdb.AddUser(user);
                DisplayAlert("Success", "Account Created!!", "OK");
                Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                DisplayAlert("Alert", "Confirm Password not correct", "OK");
            }
        }
        public void onUserTypeChanged(object s, EventArgs args)
        {           
            if (userType.SelectedIndex == 1)
            {
                bookOwner.IsVisible = true;
                var owners = _userdb.GetBookOwnerNames();
                foreach (var owner in owners)
                {
                    bookOwner.Items.Add(owner.first_name+" "+owner.last_name);
                } 
            }
            else
            {
                bookOwner.IsVisible = false;
            }
        }
      
        public void canceldata(object sender, EventArgs args)
        {
            firstname.Text = "";
            lastname.Text = "";
            contactno.Text = "";
            emailaddress.Text = "";
            username.Text = "";
            password.Text = "";
            confirmpassword.Text = "";
        }
    }
}
