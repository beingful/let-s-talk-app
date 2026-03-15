using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LetUsTalk.Interfaces;
using LetUsTalk.Services.Genertor;
using LetUsTalk.Views;

namespace LetUsTalk.ViewComponents;

public sealed partial class CreateSessionModalWindowComponent : ObservableObject
{
    private readonly IWindow _mainWindow;
    private readonly IWindow _modalWindow;
    private readonly RandomStringGenerator _randomStringGenerator;

    public CreateSessionModalWindowComponent(IWindow mainWindow, IWindow modalWindow, RandomStringGenerator randomStringGenerator, SessionComponent sessionComponent)
    {
        _mainWindow = mainWindow;
        _modalWindow = modalWindow;
        _randomStringGenerator = randomStringGenerator;
        SessionComponent = sessionComponent;
    }

    [ObservableProperty]
    private SessionComponent _sessionComponent;

    [RelayCommand]
    private void Generate()
    {
        SessionComponent.SessionName = _randomStringGenerator.Generate();
        SessionComponent.ValidationMessage = null;
    }

    [RelayCommand]
    private void Create()
    {
        bool isValid = SessionComponent.IsValid();

        if (isValid)
        {
            ConferenceRoom conferenceRoom = new();

            conferenceRoom.Show();
            _mainWindow.Close();
            _modalWindow.Close();
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        _modalWindow.Close();
    }
}
