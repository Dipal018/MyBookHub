using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyBookHub.Data;
using MyBookHub.Model;

namespace MyBookHub
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
            InitializeComponent();
        }
        public void adddata(object s, EventArgs args)
        {
			var book = new Book();
			book.BookTitle = book_title.Text;
			book.ISBNnumber = isbn_number.Text;
			book.AuthorName = author_name.Text;
			book.BookCategory = book_category.Items[book_category.SelectedIndex];
			//book.NoOfBooks = no_of_books.Text;
			book.BookDescription = book_description.Text;
            app.Database.AddBook(book);
			DisplayAlert("Data Saved!", "New book '" + book_title.Text + "' has been added to your library!", "OK");
			book_title.Text = "";
			isbn_number.Text = "";
			author_name.Text = "";
			book_category.Title = "";
			//no_of_books.Text = "";
			book_description.Text = "";
		}
		public void showdata(object sender, EventArgs args)
		{
			Navigation.PushAsync(new BookListPage(null));
		}
		public void addimage(object sender, EventArgs args)
		{
			DisplayAlert("Image!", "New image will be added", "OK");
		}
    }
}
