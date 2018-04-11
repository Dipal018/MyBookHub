using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyBookHub
{
	class BookAvailabilityLabelConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool isIssued = (bool)value;
			if (isIssued)
			{
				return "Not Available";
			}
			else
			{
				return "Available";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
