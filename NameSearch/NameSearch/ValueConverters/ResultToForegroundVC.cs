﻿/* Augusto Serrao
   Deepti Aggarwal
   Hartaj Dhillon
   Gagandeep Singh
   Shoaib Hassan
*/

using System;
using System.Globalization;
using System.Windows.Data;

namespace NameSearch.ValueConverters
{
    class ResultToForegroundVC : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return MainWindow.ResultAttributesList[(int)value].foreground;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
