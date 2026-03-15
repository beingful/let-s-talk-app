using CommunityToolkit.Mvvm.ComponentModel;
using LetUsTalk.Interfaces;
using LetUsTalk.Models;

namespace LetUsTalk.ViewComponents;

public sealed partial class SessionComponent : ObservableObject
{
    private readonly Session _session;
    private readonly IValidator<Session> _validator;

    public SessionComponent(Session session, IValidator<Session> validator)
    {
        _session = session;
        _validator = validator;
    }

    [ObservableProperty]
    private string? _sessionName;

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
        _session.Name = SessionName;
        _session.Key = SessionKey;

        Result result = _validator.Validate(_session);

        if (result.Success)
        {
            ValidationMessage = null;
        }
        else
        {
            ValidationMessage = result.Message;
        }

        return result.Success;
    }
}
