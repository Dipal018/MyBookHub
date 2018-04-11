using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using MyBookHub.Model;
using Xamarin.Forms;

namespace MyBookHub.View
{
	public partial class BookListPage : ContentPage
	{
		App app = (App)Application.Current;
		ObservableCollection<Book> BookList;
		String nextPage;
		public BookListPage(List<Book> books, String nextPage)
		{
			this.nextPage = nextPage;
			Title = "Book List";
			InitializeComponent();

			if (books == null)
			{
				int userId = (int)App.Current.Properties["userId"];
				if (App.Current.Properties["userType"].Equals("Owner"))
				{
					BookList = new ObservableCollection<Book>(app.Database.GetBooks(userId).ToList());
				}
				else {
					BookList = new ObservableCollection<Book>(app.Database.GetIssuedBooksToUser(userId).ToList());
				}
			}
			else 
			{
				BookList = new ObservableCollection<Book>(books);
			}
			BookListView.ItemsSource = BookList;
		}

		//var book = new Book();
		//	if (book.IsIssued == false)
		//	{
		//		bookavail.Text = " Available";
		//	}
		//	else
		//	{
		//		bookavail.Text = "Not Availble";
		//	}


		public void RemoveBook(Book book)
		{
			BookList.Remove(book);
		}

		async void OnViewListItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			Book book = args.SelectedItem as Book;
			if (book != null)
			{
				BookListView.SelectedItem = null;
				if (nextPage.Equals("BookDetailsPage")) {
					await Navigation.PushAsync(new BookDetailsPage()
					{
						Book = book
					});
				}
				else if (nextPage.Equals("SendSMSPage")) {
					await Navigation.PushAsync(new SendSMSPage() { 
						Book = book
					});
				}

				Debug.WriteLine("Navigating to book details page");
			}

		}
	}
}
