﻿using System.Collections.Generic;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.ViewModels
{
    public class CurrentWeatherVm : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private readonly ICurrentWeatherDataProvider _currentWeatherDataProvider;

        #endregion

        #region Constructors

        public CurrentWeatherVm(ICurrentWeatherDataProvider currentWeatherDataProvider)
        {
            _currentWeatherDataProvider = currentWeatherDataProvider;

            _currentWeatherDataProvider.GetDevicesAsync().ContinueWith(task => Items = task.Result).WithBusyIndicator(this);
        }

        #endregion

        #region Properties

        public string Text { get; set; } = "Hello MugenMvvmToolkit 1";

        public string DisplayName { get; set; } = "Сейчас";

        public IList<DeviceProjection> Items { get; private set; }

        #endregion
    }
}