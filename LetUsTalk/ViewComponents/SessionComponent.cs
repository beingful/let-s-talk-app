using CommunityToolkit.Mvvm.ComponentModel;

namespace LetUsTalk.ViewComponents;

public sealed partial class SessionComponent : ObservableObject
{
    public const string InvalidSessionMessage = "Either session id or key is invalid";

    [ObservableProperty]
    private string? _sessionId;

    [ObservableProperty]
    private string? _sessionKey;

    [ObservableProperty]
    private string? _validationMessage;

    public bool HasValidationMessage => !string.IsNullOrWhiteSpace(ValidationMessage);

    partial void OnValidationMessageChanged(string? value)
    {
        OnPropertyChanged(nameof(HasValidationMessage));
    }

    public bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(SessionId) || string.IsNullOrWhiteSpace(SessionKey))
        {
            ValidationMessage = InvalidSessionMessage;
            return false;
        }

        ValidationMessage = null;
        return true;
    }
}
