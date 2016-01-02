using System;
using MugenMvvmToolkit;
using Thermometer.ViewModels.ViewModels;

namespace Thermometer.ViewModels
{
    public class App : MvvmApplication
    {
        #region Methods

        public override Type GetStartViewModelType()
        {
            return typeof (MainVm);
        }

        #endregion
    }
}