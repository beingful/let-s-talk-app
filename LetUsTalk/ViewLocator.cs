using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using LetUsTalk.ViewModels;

namespace LetUsTalk;

/// <summary>
/// Given a view model, returns the corresponding view if possible.
/// </summary>
[RequiresUnreferencedCode(
    "Default implementation of ViewLocator involves reflection which may be trimmed away.",
    Url = "https://docs.avaloniaui.net/docs/concepts/view-locator")]
public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        Control? control;

        if (param is null)
        {
            control = null;
        }
        else
        {
            string name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            Type? type = Type.GetType(name);

            if (type != null)
            {
                control = (Control)Activator.CreateInstance(type)!;
            }
            else
            {
                control = new TextBlock { Text = "Not Found: " + name };
            }
        }

        return control;
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}
