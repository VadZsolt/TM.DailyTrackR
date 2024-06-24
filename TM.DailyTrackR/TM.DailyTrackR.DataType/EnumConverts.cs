using System.Globalization;
using System.Windows.Data;

namespace TM.DailyTrackR.DataType
{
    public class EnumConverts : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Binding.DoNothing;
            return Enum.Parse(targetType, value.ToString());
        }
    }
}
