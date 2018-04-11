using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyBookHub
{
	class InvertBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool isIssued = (bool)value;
			return !isIssued;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
