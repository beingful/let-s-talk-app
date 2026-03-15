using System.Text;

namespace LetUsTalk.Services.Genertor;

public sealed class CharactersPoolBuilder
{
    private readonly StringBuilder _charactersPool = new();

    public CharactersPoolBuilder WithNumbers()
    {
        _charactersPool.Append("0123456789");
        return this;
    }

    public CharactersPoolBuilder WithLetters(LetterCase? @case = null)
    {
        if (@case is null or LetterCase.Upper)
        {
            _charactersPool.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }

        if (@case is null or LetterCase.Lower)
        {
            _charactersPool.Append("abcdefghijklmnopqrstuvwxyz");
        }

        return this;
    }

    public override string ToString()
    {
        return _charactersPool.ToString();
    }
}
