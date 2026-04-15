using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoFiLearn.App.Services;
using Microsoft.UI.Xaml;
using System.Collections.ObjectModel;

namespace LoFiLearn.App.ViewModels;

public sealed partial class MainViewModel : BaseViewModel
{
    private readonly ThemeService _themeService;
    private readonly DocumentService _documentService;
    private readonly SoundService _soundService;

    public MainViewModel(ThemeService themeService, DocumentService documentService, SoundService soundService)
    {
        _themeService = themeService;
        _documentService = documentService;
        _soundService = soundService;
        AvailableThemes = new ObservableCollection<string>(_themeService.ThemeNames);
        SelectedTheme = _themeService.ActiveTheme;
        FooterText = "Ready for a warm study session.";
    }

    public ObservableCollection<string> AvailableThemes { get; }

    [ObservableProperty]
    private string selectedTheme;

    [ObservableProperty]
    private string footerText;

    [RelayCommand]
    public void SetTheme()
    {
        if (!string.IsNullOrEmpty(SelectedTheme))
        {
            _themeService.ApplyTheme(SelectedTheme);
        }
    }

    [RelayCommand]
    public async Task NewDocumentAsync()
    {
        _documentService.NewDocument();
        FooterText = "New document created.";
        await _soundService.PlayPopAsync();
    }

    [RelayCommand]
    public async Task SaveDocumentAsync(Window window)
    {
        await _documentService.SaveDocumentAsync(window);
        FooterText = "Saved to .lofilearn file.";
        await _soundService.PlayPopAsync();
    }

    [RelayCommand]
    public async Task OpenDocumentAsync(Window window)
    {
        await _documentService.OpenDocumentAsync(window);
        FooterText = "Document loaded.";
    }
}
