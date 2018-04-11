using System;
using System.Collections.Generic;
using MyBookHub.Model;
using Xamarin.Forms;

namespace MyBookHub
{
	public partial class SendSMSPage : ContentPage
	{
		App app = (App)Application.Current;
		Book book;

		public SendSMSPage()
		{
			Title = "Send SMS";
			InitializeComponent();
		}

		public Book Book
		{
			set
			{
				book = value;
				BindingContext = value;
				return_date.Text = book.DateOfReturn.Year + "-" + book.DateOfReturn.Month + "-" + book.DateOfReturn.Day;
				var borrower = app.Database.GetUser(book.IssuedToUserId);
				usr_name.Text = borrower.first_name + " " + borrower.last_name;
				user_number.Text = borrower.contact_number;
				sms_text.Text = "This is to remind you that your book '" + buk_title.Text + "' is due on " + return_date.Text + " Kindly return it to the Library! Thank You!";
			}
			get { return book; }
		}
		async public void sendmsg(object s, EventArgs args)
		{
			if (await DisplayAlert("Send SMS", "Do you want to send SMS to the borrower?", "Yes", "No"))
			{
				var borrower = app.Database.GetUser(book.IssuedToUserId);
				var phoneNumber = borrower.contact_number;
				DependencyService.Get<SmsSender>().sendSms(phoneNumber, sms_text.Text);
				await DisplayAlert("SMS Sent!", "The SMS will be sent to the user to return a book soon", "OK");
				await Navigation.PopAsync();
			}
		}
	}
}
