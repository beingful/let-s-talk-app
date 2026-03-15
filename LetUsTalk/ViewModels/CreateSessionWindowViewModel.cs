using CommunityToolkit.Mvvm.ComponentModel;
using LetUsTalk.ViewComponents;

namespace LetUsTalk.ViewModels;

public sealed partial class CreateSessionWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private CreateSessionModalWindowComponent _createSessionModalWindowComponent;

    public CreateSessionWindowViewModel() : this(null!)
    {
    }

    public CreateSessionWindowViewModel(CreateSessionModalWindowComponent createSessionModalWindowComponent)
    {
        CreateSessionModalWindowComponent = createSessionModalWindowComponent;
    }
}
