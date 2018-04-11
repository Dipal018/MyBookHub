using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookHub.Data;
using MyBookHub.Model;



using Xamarin.Forms;

namespace MyBookHub
{
	public partial class BookDetailsPage : ContentPage
	{
		public BookDB _bookdb;
		Book book;
		public BookDetailsPage()
		{
			Title = "Book Details";
			InitializeComponent();
			Debug.WriteLine("Creating book details page");
			_bookdb = new BookDB();
		}

		public Book Book
		{
			set
			{
				book = value;
				BindingContext = book;
			}
			get { return book; }
		}

		async public void removebook(object s, EventArgs args)
		{
			if (await DisplayAlert("Remove Book", "Are you sure want to remove this book from the library?", "Yes", "No"))
			{
				_bookdb.DeleteBook(book.Id);

				NavigationPage navPage = (NavigationPage)Application.Current.MainPage; 
				IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack; 
				int lastIndex = navStack.Count - 2; 
				BookListPage bookListPage = navStack[lastIndex] as BookListPage;
				bookListPage.RemoveBook(book);

				// await DisplayAlert("Book Removed!", "Book has been removed from your library.", "OK");
				await Navigation.PopAsync();
			}
		}
		public void issuebook(object s, EventArgs args)
		{
			DisplayAlert("Book Issued!", "New image will be added", "OK");
		}
		public void returnbook(object s, EventArgs args)
		{
			DisplayAlert("Book Returned!", "New image will be added", "OK");
		}
	}
}
