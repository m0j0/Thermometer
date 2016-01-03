using System;
using MugenMvvmToolkit;
using Thermometer.ViewModels;

namespace Thermometer
{
    public class ThermometerApp : MvvmApplication
    {
        #region Methods

        public override Type GetStartViewModelType()
        {
            return typeof (MainVm);
        }

        #endregion
    }
}