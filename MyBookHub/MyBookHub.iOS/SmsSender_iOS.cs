using System;
using Foundation;
using MyBookHub.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SmsSender_iOS))]
namespace MyBookHub.iOS
{
	public class SmsSender_iOS: SmsSender
	{
		public void sendSms(string phoneNumber, string text)
		{
			var imessageTo = NSUrl.FromString("sms:" + phoneNumber);
			UIApplication.SharedApplication.OpenUrl(imessageTo);
		}
	}
}
