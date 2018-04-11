using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyBookHub.View
{
    public partial class UserHomePage : ContentPage
    {
        public UserHomePage()
        {
            InitializeComponent();
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
