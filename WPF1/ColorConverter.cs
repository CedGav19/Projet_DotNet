using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using MainView;

namespace WPF1
{
    public class ColorConverter :   IValueConverter

    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int kcal = (int)value;

            if (kcal >Data.Instance.AbonneConnected.sommekcal)
            {
                return Brushes.Red;
            }
            else
                return Brushes.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
