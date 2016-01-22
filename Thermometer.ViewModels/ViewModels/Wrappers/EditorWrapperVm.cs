using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;

namespace Thermometer.ViewModels.Wrappers
{
    public class EditorWrapperVm : WrapperViewModelBase<IEditableViewModel>, IEditorWrapperVm
    {
        #region Constructors

        public EditorWrapperVm()
        {
            SaveCommand = RelayCommandBase.FromAsyncHandler<object>(SaveAsync, CanSave, false, this);
        }

        #endregion

        #region Implementation of IEditableWindowViewModel

        public ICommand SaveCommand { get; set; }

        #endregion

        #region Overrides of WrapperViewModelBase<T>

        protected override void OnClosed(object parameter)
        {
            if (!OperationResult.GetValueOrDefault() && ViewModel != null && ViewModel.IsEntityInitialized)
            {
                ViewModel.CancelChanges();
            }
        }

        #endregion

        #region Command's methosd

        private Task SaveAsync(object obj)
        {
            OperationResult = true;
            return CloseAsync(obj).WithBusyIndicator(this);
        }

        private bool CanSave(object obj)
        {
            return ViewModel != null && ViewModel.HasChanges && ViewModel.IsValid;
        }

        #endregion
    }
}