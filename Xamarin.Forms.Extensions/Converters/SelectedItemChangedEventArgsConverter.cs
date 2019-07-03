using System;
using System.Globalization;

namespace Xamarin.Forms.Converters
{
    public class SelectedItemChangedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as SelectedItemChangedEventArgs;
            if (eventArgs == null)
                throw new ArgumentException("Expected SelectedItemChangedEventArgs as value", "value");

            return eventArgs.SelectedItem;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}