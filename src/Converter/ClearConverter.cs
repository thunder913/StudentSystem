using System;
using System.Globalization;
using System.Windows.Data;

namespace StudentSystem.Converter
{
    public class ClearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
            {
                return index != -1;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}