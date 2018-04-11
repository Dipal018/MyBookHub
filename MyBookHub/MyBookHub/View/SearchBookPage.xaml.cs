using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MyBookHub.Model;
using Xamarin.Forms;

namespace MyBookHub.View
{
	public partial class SearchBookPage : ContentPage
	{
		App app = (App)Application.Current;

		public SearchBookPage()
		{
			Title = "Book Search";
			InitializeComponent();
		}


		public async void searchdata(object s, EventArgs args)
		{
			List<Book> bookList = null;
			int userId = (int)app.Properties["userId"];
			if (searchpicker.SelectedIndex == 0)
			{
				bookList = app.Database.SearchBookByTitle(searchQuery.Text, userId).ToList();
			}
			else if (searchpicker.SelectedIndex == 1)
			{
				bookList = app.Database.SearchBookByAuthor(searchQuery.Text, userId).ToList();
			}
			else if (searchpicker.SelectedIndex == 2)
			{
				bookList = app.Database.SearchBookByCategory(selectcategory.Items[selectcategory.SelectedIndex], userId).ToList();
			}
			await Navigation.PushAsync(new BookListPage(bookList, "BookDetailsPage"));
		}

		void Handle_SearchBy_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			var picker = sender as Picker;
			if (picker == searchpicker)
			{
				if (searchpicker.SelectedIndex == 2)
				{
					entrylbl.Text = "Select here:";
					searchQuery.IsEnabled = false;
					searchQuery.IsVisible = false;
					selectcategory.IsEnabled = true;
					selectcategory.IsVisible = true;
				}
				else 
				{
					entrylbl.Text = "Enter here:";
					searchQuery.IsEnabled = true;
					searchQuery.IsVisible = true;
					selectcategory.IsEnabled = false;
					selectcategory.IsVisible = false;
				}
			}
		}
	}
}
