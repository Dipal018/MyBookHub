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
        App app = (App)Application.Current;

        public SignUpPage()
        {
			Title = "Sign Up";
            InitializeComponent();
            this.BackgroundColor = Color.FromHex("#FDF2E9");
        }
        async void adduser(object s, EventArgs args)
        {
            var user = new User();
            user.first_name = firstname.Text;
            user.last_name = lastname.Text;
            user.contact_number =contactno.Text;
            user.email_id = emailaddress.Text;
            user.user_name = username.Text;
            user.user_type = userType.Items[userType.SelectedIndex];
            if (user.user_type.Equals("Borrower"))
            {
                string val = bookOwner.Items[bookOwner.SelectedIndex];
                //Debug.WriteLine("BOOK OWNER NAME SELECTED :::::" + val);
               
                string[] name = val.Split(' ');
				User u = app.Database.GetBookOwnerId(name[0], name[1]);
                user.owner_id = u.user_id;
            }

            if (contactno.Text.Contains("."))
			{
				await DisplayAlert("Error", "Contact number can have only numeric values!!", "ok");
			}
			else
			{
				if (confirmPasswordBehavior.IsValid)
				{
					user.password = password.Text;
					app.Database.AddUser(user);
					await DisplayAlert("Success", "Account Created!!", "OK");
					await Navigation.PopAsync();
				}
				else
				{
					await DisplayAlert("Alert", "Confirm Password not correct", "OK");
				}
			}
		}
        public void onUserTypeChanged(object s, EventArgs args)
        {           
            if (userType.SelectedIndex == 1)
            {
                bookOwner.IsVisible = true;
				var owners = app.Database.GetBookOwnerNames();
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
      
        async public void canceldata(object sender, EventArgs args)
        {
            firstname.Text = "";
            lastname.Text = "";
            contactno.Text = "";
            emailaddress.Text = "";
            username.Text = "";
            password.Text = "";
            confirmpassword.Text = "";
			await Navigation.PopAsync();

        }
		void OnTextChanged(object sender, EventArgs e)
		{
			if (contactno.Text.Contains("."))
			{
				DisplayAlert("Error", "InCorrect Contact Number", "OK");
			}
		}
    }
}
