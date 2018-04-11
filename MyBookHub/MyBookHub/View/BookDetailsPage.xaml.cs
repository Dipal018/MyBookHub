using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookHub.Model;
using Xamarin.Forms;

namespace MyBookHub.View
{
	public partial class BookDetailsPage : ContentPage
	{
		App app = (App)Application.Current;
		Book book;
	
		public BookDetailsPage()
		{
			Title = "Book Details";
			InitializeComponent();
			foreach (User user in app.Database.GetUsersByType("Borrower"))
			{
				user_namepicker.Items.Add(user.user_name);
			}
			returndatepicker.MinimumDate = DateTime.Today;
			returndatepicker.Date = DateTime.Today + TimeSpan.FromDays(7);
			if (app.Properties["userType"].Equals("Borrower"))
			{
				issuebtn.IsVisible = false;
				removebtn.IsVisible = false;
				returnbtn.IsVisible = false;
			}
		}

		public Book Book
		{
			set
			{
				book = value;
				BindingContext = value;
				if (book.IsIssued)
				{
					var borrower = app.Database.GetUser(book.IssuedToUserId);
					issued_to.Text = borrower.first_name + " " + borrower.last_name;
				}
			}
			get { return book; }
		}

		async public void removebook(object s, EventArgs args)
		{
			if (await DisplayAlert("Remove Book", "Are you sure want to remove this book from the library?", "Yes", "No"))
			{
				app.Database.DeleteBook(book.Id);
				removeBookFromBackstack();
				await DisplayAlert("Book Removed!", "Book has been removed from your library.", "OK");
				await Navigation.PopAsync();
			}
		}

		async void issuebook(object s, EventArgs args)
		{
			if (!issueGrid.IsVisible)
			{
				issueGrid.IsVisible = true;
			}
			else {
				if (await DisplayAlert("Issue Book", "Are you sure want to issue this book?", "Yes", "No"))
				{
					User borrower = app.Database.GetUserByUserName(user_namepicker.Items[user_namepicker.SelectedIndex]);
					app.Database.IssueBook(book, borrower.user_id, issuedatepicker.Date, returndatepicker.Date);
					await DisplayAlert("Book Issued!", "You book has been issued!", "OK");
					await Navigation.PopAsync();
				}
			}
		}

		async public void returnbook(object s, EventArgs args)
		{
			if (await DisplayAlert("Return Book", "Are you sure want to return this book?", "Yes", "No"))
			{
				app.Database.ReturnIssuedBook(book);
				await DisplayAlert("Book Returned!", "You book has been returned!", "OK");
				await Navigation.PopAsync();
			}
		}

		public void onpickervaluechanged(object s, EventArgs args)
		{
			if (s == issuedatepicker)
			{
				returndatepicker.MinimumDate = issuedatepicker.Date;
				returndatepicker.Date = issuedatepicker.Date + TimeSpan.FromDays(7);
			}
		}

		private void removeBookFromBackstack()
		{
			NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
			IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
			int lastIndex = navStack.Count - 2;
			BookListPage bookListPage = navStack[lastIndex] as BookListPage;
			bookListPage.RemoveBook(book);
		}
	}
}