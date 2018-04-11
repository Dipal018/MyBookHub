using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyBookHub
{
	public class DateToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			DateTime date = (DateTime)value;
			return date.Year + "-" + date.Month + "-" + date.Day;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		
	}
}
