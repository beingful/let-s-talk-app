using System;
using CommunityToolkit.Mvvm.ComponentModel;
using LetUsTalk.Interfaces;
using LetUsTalk.ViewComponents;

namespace LetUsTalk.ViewModels;

public sealed partial class ConferenceRoomViewModel : ViewModelBase, IInitializable, IDisposable
{
    [ObservableProperty]
    private CameraContainerComponent _cameraContainerComponent;

    [ObservableProperty]
    private ConferenceMenuComponent _menuComponent;

    public ConferenceRoomViewModel(CameraContainerComponent cameraContainerComponent, ConferenceMenuComponent menuComponent)
    {
        CameraContainerComponent = cameraContainerComponent;
        MenuComponent = menuComponent;
    }

    public void Initialize()
    {
        CameraContainerComponent.Initialize();
    }

    public void Dispose()
    {
        CameraContainerComponent.Dispose();
    }
}
