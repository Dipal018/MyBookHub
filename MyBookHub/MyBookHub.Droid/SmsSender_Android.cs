using System;
using Android.Telephony;
using MyBookHub.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SmsSender_Android))]
namespace MyBookHub.Droid
{	
	public class SmsSender_Android : SmsSender
	{
		public void sendSms(string phoneNumber, string text)
		{
			SmsManager.Default.SendTextMessage(phoneNumber, null, text, null, null);
		}
	}
}
