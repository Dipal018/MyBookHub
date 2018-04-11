using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyBookHub.View
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            //  this.BackgroundImage = "imgBook.jpg";
            this.BackgroundColor = Color.FromHex("#FDF2E9");
        }
        void OnTapGestureProfileTapped(object sender, EventArgs args)
        {
            // DisplayAlert("Alert", "profile", "ok");
            Navigation.PushModalAsync(new ProfilePage());
        }
        void OnTapGestureMyBooksTapped(object sender, EventArgs args)
        {
            DisplayAlert("Alert", "my books", "ok");
        }
        void OnTapGestureAddBookTapped(object sender, EventArgs args)
        {
            DisplayAlert("Alert", "add book", "ok");
        }
        void OnTapGestureRemoveBookTapped(object sender, EventArgs args)
        {
            DisplayAlert("Alert", "remove book", "ok");
        }
        void OnTapGestureIssueBookTapped(object sender, EventArgs args)
        {
            DisplayAlert("Alert", "issue book", "ok");
        }
        void OnTapGestureReturnBookTapped(object sender, EventArgs args)
        {
            DisplayAlert("Alert", "return book", "ok");
        }
        void OnTapGestureScanTapped(object sender, EventArgs args)
        {
            DisplayAlert("Alert", "scan", "ok");
        }
        void OnTapGestureSendSMSTapped(object sender, EventArgs args)
        {
            DisplayAlert("Alert", "send sms", "ok");
        }
        void OnTapGestureAboutAppTapped(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new AboutAppPage());
        }
        void OnTapGestureSignOutTapped(object sender, EventArgs args)
        {
            //DisplayAlert("Alert", "signout", "ok");
            App.Current.Properties["isLoggedIn"] = false;
            Navigation.PushModalAsync(new LoginPage());
        }
    }
}
