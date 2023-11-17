using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesAPI.Controllers {
    public class MyUtilities: IValueConverter {



        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            switch (value) {
                case byte[] fotoBytes:
                    byte[] arr1 = value as byte[];
                    return ImageSource.FromStream(() => new MemoryStream(arr1));

                case string flagUri:
                    return ImageSource.FromUri(new Uri(value as string));

                default: return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
