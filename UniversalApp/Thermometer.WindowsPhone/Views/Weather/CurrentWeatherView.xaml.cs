using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using MugenMvvmToolkit.WinRT.Binding;

namespace Thermometer.Views.Weather
{
    public sealed partial class CurrentWeatherView : UserControl
    {
        public CurrentWeatherView()
        {
            InitializeComponent();
        }

        private void SensorItemHolding(object sender, HoldingRoutedEventArgs e)
        {
            var senderElement = sender as FrameworkElement;
            if (senderElement == null)
            {
                return;
            }
            FlyoutBase.GetAttachedFlyout(senderElement)?.ShowAtEx(senderElement);
        }
    }
}