using System.Collections.Generic;
using System.Linq;

namespace LetUsTalk.Utilities.UI;

internal class RunningCaption : ICaption
{
    private readonly string _content;
    private int _textOffset;

    private RunningCaption(string content)
    {
        _content = content;
        _textOffset = 0;
    }

    public string Text()
    {
        _textOffset = (_textOffset + 1) % _content.Length;
        
        return _content[_textOffset..] + _content[.._textOffset];
    }

    public static RunningCaption CreateWithNoSpaces(string text, char delimeter, byte delimeterRepeats = 1)
    {
        if (delimeter != ' ')
        {
            text = text.Replace(' ', delimeter);
        }

        return Create(text, delimeter, delimeterRepeats);
    }

    public static RunningCaption Create(string text, char delimeter, byte delimeterRepeats = 1)
    {
        IEnumerable<char> delimeterLine = Enumerable.Repeat(delimeter, delimeterRepeats);

        string runningContent = string.Join(string.Empty, delimeterLine.Concat(text).Concat(delimeterLine));

        return new RunningCaption(runningContent);
    }
}