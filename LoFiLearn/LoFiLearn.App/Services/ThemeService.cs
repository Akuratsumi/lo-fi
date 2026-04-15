using Microsoft.UI.Xaml;
using System;
using System.Linq;

namespace LoFiLearn.App.Services;

public sealed class ThemeService
{
    private readonly ResourceDictionary _applicationResources = Application.Current.Resources;

    public IReadOnlyList<string> ThemeNames { get; } = new[]
    {
        "Default",
        "Forest",
        "Twilight",
        "Blossom",
        "Matcha",
        "Sunset",
        "Coastal",
        "Stone",
        "Navy",
        "Olive"
    };

    public string ActiveTheme { get; private set; } = "Default";

    public void ApplyTheme(string themeName)
    {
        if (string.Equals(themeName, ActiveTheme, StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        var uri = new Uri($"ms-appx:///Themes/{themeName}Theme.xaml");
        var dictionary = new ResourceDictionary { Source = uri };

        var existing = _applicationResources.MergedDictionaries.FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Theme.xaml"));
        if (existing != null)
        {
            _applicationResources.MergedDictionaries.Remove(existing);
        }

        _applicationResources.MergedDictionaries.Add(dictionary);
        ActiveTheme = themeName;
    }
}
