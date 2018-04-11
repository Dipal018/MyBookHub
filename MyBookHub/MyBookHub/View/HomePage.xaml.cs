using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyBookHub.View
{
    public partial class HomePage : ContentPage
    {
		App app = (App)Application.Current;
        public HomePage()
        {
			Title = "BookHub";
			//NavigationPage.SetHasNavigationBar(this, false);
			//NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
			//NavigationPage.SetHasBackButton(this, false);
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
			else if (toolbarItem.Text.Equals("Add a Book"))
			{
				await Navigation.PushAsync(new AddBookPage());
			}
			else if (toolbarItem.Text.Equals("Remove a Book"))
			{
				await Navigation.PushAsync(new SearchBookPage());
			}
			else if (toolbarItem.Text.Equals("Issue a Book"))
			{
				await Navigation.PushAsync(new SearchBookPage());
			}
			else if (toolbarItem.Text.Equals("Return a Book"))
			{
				await Navigation.PushAsync(new SearchBookPage());
			}
			else if (toolbarItem.Text.Equals("Scan"))
			{
				var scanner = new ZXing.Mobile.MobileBarcodeScanner();
				var result = await scanner.Scan();

				if (result != null)
				{
					Debug.WriteLine("Scanned Barcode: " + result.Text);
					int currentuserid = (int)app.Properties["userId"];
					var book = app.Database.GetBookByBarcode(result.Text, currentuserid);
					if (book != null)
					{
						await Task.Delay(300);
						await Navigation.PushAsync(new BookDetailsPage()
						{
							Book = book
						});
					}
					else 
					{
						if (await DisplayAlert("Not Found!", "Book with ISBN " + result.Text + " not found. Do you want to add this book in Library?", "Yes", "No"))
						{
							await Navigation.PushAsync(new AddBookPage()
							{
								ISBN = result.Text
							});
						}	
					}
				}

   		    }
			else if (toolbarItem.Text.Equals("Send Notification"))
			{
				int currentuserid = (int)app.Properties["userId"];
				var issuedbooklist = app.Database.GetIssuedBooksFromUser(currentuserid).ToList();
				await Navigation.PushAsync(new BookListPage(issuedbooklist, "SendSMSPage"));
			}
			else if (toolbarItem.Text.Equals("About This App"))
			{
				await Navigation.PushAsync(new AboutAppPage());
			}
			else if (toolbarItem.Text.Equals("SignOut"))
			{
				app.User = null;
				app.Properties["isLoggedIn"] = false;
				await Navigation.PopAsync();
			}
		}
    }
}
