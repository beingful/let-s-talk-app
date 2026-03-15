using LetUsTalk.Models;

namespace LetUsTalk.Interfaces;

public interface IValidator<TModel>
{
    Result Validate(TModel model);
}
