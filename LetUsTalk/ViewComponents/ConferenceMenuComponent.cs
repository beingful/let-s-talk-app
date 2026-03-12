using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LetUsTalk.ViewComponents;

public sealed partial class ConferenceMenuComponent : ObservableObject
{
    [ObservableProperty]
    private ChatComponent _chatComponent;

    public ConferenceMenuComponent(ChatComponent chatComponent)
    {
        ChatComponent = chatComponent;
    }

    [RelayCommand]
    private void ChatToggleButtonClick()
    {
        ChatComponent.Expanded = !ChatComponent.Expanded;
    }
}
