using System;
namespace MyBookHub
{
	public interface SmsSender
	{
		void sendSms(string phoneNumber, string text);
	}
}
