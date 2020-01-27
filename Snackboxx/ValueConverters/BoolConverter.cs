using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace Snackboxx.ValueConverters
{
    [ValueConversion(typeof(object), typeof(bool))]
    public sealed class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case bool b:
                    return b;
                case string s:
                    return !string.IsNullOrEmpty(s);
                case IEnumerable enumerable:
                    return enumerable.GetEnumerator().MoveNext();
                default:
                    try
                    {
                        return System.Convert.ToDouble(value) > 0;
                    }
                    catch (InvalidCastException )
                    {
                    }
                    return value != null;
            }
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}