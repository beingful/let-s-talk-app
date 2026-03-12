using System;
using CommunityToolkit.Mvvm.ComponentModel;
using LetUsTalk.Interfaces;

namespace LetUsTalk.ViewComponents;

public sealed partial class CameraContainerComponent : ObservableObject, IInitializable, IDisposable
{
    [ObservableProperty]
    private CameraComponent _cameraComponent;

    [ObservableProperty]
    private DraggableBorderComponent _borderComponent;

    public CameraContainerComponent(CameraComponent cameraComponent, DraggableBorderComponent borderComponent)
    {
        CameraComponent = cameraComponent;
        BorderComponent = borderComponent;
    }

    public void Initialize()
    {
        CameraComponent.Initialize();
    }

    public void Dispose()
    {
        CameraComponent.Dispose();
    }
}
