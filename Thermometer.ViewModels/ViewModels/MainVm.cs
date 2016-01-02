using MugenMvvmToolkit.ViewModels;

namespace Thermometer.ViewModels.ViewModels
{
    public class MainVm : CloseableViewModel
    {
        #region Fields

        private string _text = "Hello MugenMvvmToolkit";

        #endregion

        #region Properties

        public string Text
        {
            get { return _text; }
            set
            {
                if (Equals(_text, value))
                    return;
                _text = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}