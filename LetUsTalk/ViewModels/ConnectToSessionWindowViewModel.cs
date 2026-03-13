using CommunityToolkit.Mvvm.ComponentModel;
using LetUsTalk.ViewComponents;

namespace LetUsTalk.ViewModels;

public sealed partial class ConnectToSessionWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private SessionModalWindowComponent _sessionModalWindowComponent;

    public ConnectToSessionWindowViewModel() : this(null!)
    {
    }

    public ConnectToSessionWindowViewModel(SessionModalWindowComponent sessionModalWindowComponent)
    {
        SessionModalWindowComponent = sessionModalWindowComponent;
    }
}
