using LetUsTalk.Interfaces;
using LetUsTalk.Models;

namespace LetUsTalk.Services.Validation;

public sealed class CreateSessionValidator : IValidator<Session>
{
    public Result Validate(Session model)
    {
        Result result;

        if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Trim().Length < 4)
        {
            result = Result.Error("Enter a session name with at least 4 characters.");
        }
        else
        {
            result = Result.Ok();
        }

        return result;
    }
}
