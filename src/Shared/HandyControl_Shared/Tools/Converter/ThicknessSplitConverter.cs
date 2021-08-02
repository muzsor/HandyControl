using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HandyControl.Tools.Converter
{
    public class ThicknessSplitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness thickness)
            {
                if (parameter is string str)
                {
                    var arr = str.Split(',');
                    if (arr.Length != 4) return thickness;

                    return new Thickness(
                        arr[0].Equals("-") ? thickness.Left : double.Parse(arr[0]),
                        arr[1].Equals("-") ? thickness.Top : double.Parse(arr[1]),
                        arr[2].Equals("-") ? thickness.Right : double.Parse(arr[2]),
                        arr[3].Equals("-") ? thickness.Bottom : double.Parse(arr[3]));
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
