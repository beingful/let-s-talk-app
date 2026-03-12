using CommunityToolkit.Mvvm.ComponentModel;

namespace LetUsTalk.ViewComponents;

public sealed partial class ChatComponent : ObservableObject
{
    [ObservableProperty]
    private bool _expanded;

    public ChatComponent(bool expanded = false)
    {
        Expanded = expanded;
    }
}