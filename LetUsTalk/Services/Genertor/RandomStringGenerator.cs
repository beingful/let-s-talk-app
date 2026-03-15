using System;

namespace LetUsTalk.Services.Genertor;

public sealed class RandomStringGenerator
{
    private readonly string _charactersPool;
    private readonly int _maxLength;
    private readonly int _minLength;
    private readonly Random _random;

    public RandomStringGenerator(string charactersPool, int minLength, int maxLength)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(charactersPool);

        if (minLength <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(minLength));
        }

        if (maxLength < minLength)
        {
            throw new ArgumentOutOfRangeException(nameof(maxLength));
        }

        _charactersPool = charactersPool;
        _minLength = minLength;
        _maxLength = maxLength;
        _random = Random.Shared;
    }

    public string Generate()
    {
        int length = _random.Next(_minLength, _maxLength + 1);
        char[] generatedString = new char[length];

        for (int index = 0; index < generatedString.Length; index++)
        {
            generatedString[index] = _charactersPool[_random.Next(_charactersPool.Length)];
        }

        return new string(generatedString);
    }
}
