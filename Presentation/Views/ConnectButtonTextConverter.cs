using System;
using System.Globalization;
using System.Windows.Data;

namespace KeenVPN.Presentation.Views
{
    public class ConnectButtonTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool isConnected && isConnected) ? "Disconnect" : "Connect";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
