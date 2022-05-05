using System;
using System.Globalization;
using System.Windows.Data;
using StudentSystemCommon.Utils;

namespace StudentSystemCommon.Converter
{
    public class LengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
                return text.Length >= (UserInfo.CurrentUser == null
                    ? 1
                    : UserInfo.CurrentUser.Settings.InputLengthThreshold);
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
