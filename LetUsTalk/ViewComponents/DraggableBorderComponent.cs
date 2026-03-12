using System;
using Avalonia.Controls;
using Avalonia.Input;
using CommunityToolkit.Mvvm.Input;

namespace LetUsTalk.ViewComponents;

public sealed partial class DraggableBorderComponent
{
    private readonly Border _borderControl;

    public DraggableBorderComponent(Border borderControl)
    {
        _borderControl = borderControl;
    }

    [RelayCommand]
    private void ResizeOnDrag(VectorEventArgs e)
    {
        _borderControl.Height = Math.Clamp(_borderControl.Height + e.Vector.Y, _borderControl.MinHeight, _borderControl.MaxHeight);
        _borderControl.Width = Math.Clamp(_borderControl.Width + e.Vector.X, _borderControl.MinWidth, _borderControl.MaxWidth);
    }
}
