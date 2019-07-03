using System;
using System.Globalization;

namespace Xamarin.Forms.Converters
{
    public class ConcatImageExtensionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fileName = value as string;

            if (fileName == null)
            {
                return null;
            }

            return string.Concat(fileName, ".png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
