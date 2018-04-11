using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using MyBookHub.Data;
using MyBookHub.Model;

namespace MyBookHub
{
    public partial class BookListPage : ContentPage
    {
        public BookDB _database;
		public ObservableCollection<Book> books;
		public BookListPage(List<Book> books)
        {
			Title = "Book List";
        InitializeComponent();

            _database = new BookDB();
			this.books = new ObservableCollection<Book>(books);
			if (this.books == null)
			{
				this.books = new ObservableCollection<Book>(_database.GetBooks().ToList());
			}
			// var books = _database.GetBooks();
			//if (SearchBookPage.seachpicker.text == "Book Title")
			//{
				// var books = _database.SearchBookByTitle("book");
			//}
            BookListView.ItemsSource = this.books;
        }

		public void RemoveBook(Book book)
		{
			books.Remove(book);
		}

		async void OnViewListItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			Book book = args.SelectedItem as Book;
			if (book != null)
			{
				BookListView.SelectedItem = null;
				await Navigation.PushAsync(new BookDetailsPage()
				{
					Book = book
				});

				Debug.WriteLine("Navigating to book details page");
			}

		}
	}
}
