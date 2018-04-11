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
		App app = (App)Application.Current;
        public UserHomePage()
        {
			Title = "Home Page";
			//NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            this.BackgroundColor = Color.FromHex("#FDF2E9");
        }

		protected override Boolean OnBackButtonPressed()
		{

			DisplayAlert("Wrong Way", "Click Signout to exit from the app", "OK").ContinueWith(t => { }, TaskScheduler.FromCurrentSynchronizationContext());
			return true;
		}

		async void OnToolbarItemClicked(object sender, EventArgs args)
		{
			ToolbarItem toolbarItem = (ToolbarItem)sender;
			if (toolbarItem.Text.Equals("search"))
			{
				await Navigation.PushAsync(new SearchBookPage());
			}
			else if (toolbarItem.Text.Equals("My Profile"))
			{
				await Navigation.PushAsync(new ProfilePage());
			}
			else if (toolbarItem.Text.Equals("My Books"))
			{
				await Navigation.PushAsync(new BookListPage(null, "BookDetailsPage"));
			}
			else if (toolbarItem.Text.Equals("About This App"))
			{
				await Navigation.PushAsync(new AboutAppPage());
			}
			else if (toolbarItem.Text.Equals("SignOut"))
			{
				app.User = null;
				App.Current.Properties["isLoggedIn"] = false;
				await Navigation.PopAsync();
			}
		}

    }
}
