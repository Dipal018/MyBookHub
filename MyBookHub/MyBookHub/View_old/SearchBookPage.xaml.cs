using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using MyBookHub.Data;
using MyBookHub.Model;

namespace MyBookHub
{
	public partial class SearchBookPage : ContentPage
	{
		public BookDB _bookdb;
		public Book book;
		public SearchBookPage()
		{
			Title = "BookHub";
			InitializeComponent();
			_bookdb = new BookDB();
		}
		public void searchdata(object s, EventArgs args)
		{
			List<Book> bookList = null;
			if (searchpicker.SelectedIndex == 0)
			{
				entrylbl.Text = "Enter here:";
				searchQuery.IsVisible = true;
				selectcategory.IsVisible = false;
				bookList = _bookdb.SearchBookByTitle(searchQuery.Text).ToList();
			}
			else if (searchpicker.SelectedIndex == 1)
			{
				entrylbl.Text = "Enter here:";
				searchQuery.IsVisible = true;
				selectcategory.IsVisible = false;
				bookList = _bookdb.SearchBookByAuthor(searchQuery.Text).ToList();
			}
			else if (searchpicker.SelectedIndex == 2)
			{
				entrylbl.Text = "Select here:";
				searchQuery.IsEnabled = false;
				searchQuery.IsVisible = false;
				selectcategory.IsEnabled = true;
				selectcategory.IsVisible = true;
				testlbl.Text = selectcategory.Items[selectcategory.SelectedIndex];
				bookList = _bookdb.SearchBookByCategory(selectcategory.Items[selectcategory.SelectedIndex]).ToList();
			}
			Navigation.PushAsync(new BookListPage(bookList));
		}
	}
}
