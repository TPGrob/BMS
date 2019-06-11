using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace BMS.Kassa
{
    class AantalToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int i = int.Parse(value.ToString());
             BrushConverter con = new BrushConverter();
            if (i >= 10) 
            {
                return con.ConvertFromString("#FFD3D3D3") as Brush;
            }
            else if (i > 0 && i < 10)
            {
                return con.ConvertFromString("#FFFF6600") as Brush;
            }
            else {
                return con.ConvertFromString("#FFFF0000") as Brush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
