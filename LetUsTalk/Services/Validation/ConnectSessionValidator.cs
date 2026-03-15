using LetUsTalk.Interfaces;
using LetUsTalk.Models;

namespace LetUsTalk.Services.Validation;

public sealed class ConnectSessionValidator : IValidator<Session>
{
    public Result Validate(Session model)
    {
        Result result;

        if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Key))
        {
            result = Result.Error("Either session name or key is invalid");
        }
        else
        {
            result = Result.Ok();
        }

        return result;
    }
}
