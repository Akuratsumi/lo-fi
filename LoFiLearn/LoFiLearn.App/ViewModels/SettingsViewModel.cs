using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoFiLearn.App.Services;
using System.Collections.ObjectModel;
using Windows.Globalization;

namespace LoFiLearn.App.ViewModels;

public sealed partial class SettingsViewModel : BaseViewModel
{
    private readonly ThemeService _themeService;
    private readonly SoundService _soundService;
    private readonly AppSettings _appSettings;

    public SettingsViewModel(ThemeService themeService, SoundService soundService, AppSettings appSettings)
    {
        _themeService = themeService;
        _soundService = soundService;
        _appSettings = appSettings;

        AvailableLanguages = new ObservableCollection<string> { "en-US", "ru-RU" };
        SelectedLanguage = ApplicationLanguages.PrimaryLanguageOverride ?? "en-US";
        SelectedTheme = _themeService.ActiveTheme;
        Volume = _appSettings.Volume;
    }

    public ObservableCollection<string> AvailableLanguages { get; }

    [ObservableProperty]
    private string selectedLanguage;

    [ObservableProperty]
    private string selectedTheme;

    [ObservableProperty]
    private double volume;

    [RelayCommand]
    public void ApplyLanguage()
    {
        if (!string.IsNullOrEmpty(SelectedLanguage))
        {
            ApplicationLanguages.PrimaryLanguageOverride = SelectedLanguage;
        }
    }

    [RelayCommand]
    public void ApplyTheme()
    {
        _themeService.ApplyTheme(SelectedTheme);
    }

    [RelayCommand]
    public void SetVolume(double value)
    {
        Volume = value;
        _appSettings.Volume = value;
        _soundService.Volume = value;
    }
}
