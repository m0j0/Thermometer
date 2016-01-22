using System.Windows.Input;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.ViewModels;

namespace Thermometer.Interfaces
{
    public interface IEditorWrapperVm : IWrapperViewModel, ICloseableViewModel, IHasDisplayName
    {
        ICommand SaveCommand { get; set; }
    }
}