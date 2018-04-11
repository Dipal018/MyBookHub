using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookHub.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBookHub.View
{
	// This class required to use ImageResource method
	[ContentProperty("Source")]
	public class ImageResourceExtension : IMarkupExtension
	{
		public string Source { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (Source == null)
				return null;
			return ImageSource.FromResource(Source);
		}
	}
	public partial class AddBookPage : ContentPage
	{
		App app = (App)Application.Current;
		public AddBookPage()
		{
			Title = "Add Book";
			InitializeComponent();
		}

		public string ISBN
		{
			set
			{
				isbn_number.Text = value;
			}
			get { return isbn_number.Text; }
		}

		async void adddata(object s, EventArgs args)
		{
			var book = new Book();
			book.BookTitle = book_title.Text;
			book.ISBNnumber = isbn_number.Text;
			book.AuthorName = author_name.Text;
			book.BookCategory = book_category.Items[book_category.SelectedIndex];
			book.BookDescription = book_description.Text;
			book.owner_id = (int)App.Current.Properties["userId"];

			if (!isbn_number.Text.Contains("."))
			{
				app.Database.AddBook(book);
				await DisplayAlert("Data Saved!", "New book '" + book_title.Text + "' has been added to your library!", "OK");
				await Navigation.PopAsync();
			}
			else
			{
				await DisplayAlert("Error", "ISBN number can only have numeric values", "ok");
			}
		}
		async void cancel(object sender, EventArgs args)
		{
			await Navigation.PopAsync();
		}
		async void addimage(object sender, EventArgs args)
		{
			await DisplayAlert("Image!", "New image will be added", "OK");
		}
		void OnTextChanged(object sender, EventArgs e)
		{
			if (isbn_number.Text.Contains("."))
			{
				DisplayAlert("Error", "InCorrect ISBN Number", "ok");
			}
		}
	}
}
