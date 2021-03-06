﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ChoETL
{
    [ChoTypeConverter(typeof(DateTime))]
    public class ChoDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                string text = value as string;
                if (!text.IsNullOrWhiteSpace())
                {
                    string format = parameter.GetValueAt<string>(0, ChoTypeConverterFormatSpec.Instance.Value.DateTimeFormat);
                    return !format.IsNullOrWhiteSpace() ? DateTime.ParseExact(text, format, culture) : value;
                }
            }
            
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is DateTime)
            {
                string format = parameter.GetValueAt<string>(0, ChoTypeConverterFormatSpec.Instance.Value.DateTimeFormat);
                return !format.IsNullOrWhiteSpace() ? ((DateTime)value).ToString(format, culture) : value;
            }
            else
                return value;
        }
    }
}
