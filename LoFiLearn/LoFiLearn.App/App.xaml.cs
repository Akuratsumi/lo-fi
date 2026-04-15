using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using LoFiLearn.App.Services;
using LoFiLearn.App.ViewModels;

namespace LoFiLearn.App;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = null!;

    public App()
    {
        InitializeComponent();
        ConfigureServices();
        RequestedTheme = ApplicationTheme.Light;
    }

    private void ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ThemeService>();
        services.AddSingleton<DocumentService>();
        services.AddSingleton<SoundService>();
        services.AddSingleton<AppSettings>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<SurveyViewModel>();
        services.AddSingleton<FlashcardsViewModel>();
        services.AddSingleton<DragDropViewModel>();
        services.AddSingleton<StepGuideViewModel>();
        services.AddSingleton<MatchingViewModel>();
        services.AddSingleton<SortingViewModel>();
        services.AddSingleton<SettingsViewModel>();

        Services = services.BuildServiceProvider();
    }

    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        var window = new MainWindow();
        window.Activate();
    }
}
