using System;
using Windows.Foundation;
using Windows.UI.Xaml.Data;
using Thermometer.Modules;

namespace Thermometer.Converters
{
    internal class SizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var sizeModel = value as SizeModel ?? SizeModel.Empty;
            return new Size(sizeModel.Width, sizeModel.Height);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var size = (Size) value;
            return new SizeModel(size.Width, size.Height);
        }
    }

    internal class PointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var sizeModel = value as SizeModel ?? SizeModel.Empty;
            return new Point(sizeModel.Width, sizeModel.Height);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var size = (Point) value;
            return new SizeModel(size.X, size.Y);
        }
    }
}