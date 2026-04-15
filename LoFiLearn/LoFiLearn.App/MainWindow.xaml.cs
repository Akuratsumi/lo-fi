using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using LoFiLearn.App.ViewModels;
using WinRT.Interop;

namespace LoFiLearn.App;

public sealed partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = App.Services.GetRequiredService<MainViewModel>();
        DataContext = _viewModel;

        ExtendsContentIntoTitleBar = true;
        SetTitleBar(CustomTitleBar);

        ContentFrame.NavigationFailed += OnNavigationFailed;
        ContentFrame.Navigate(typeof(Pages.SurveyPage), null, new Microsoft.UI.Xaml.Media.Animation.SlideNavigationTransitionInfo { Effect = Microsoft.UI.Xaml.Media.Animation.SlideNavigationTransitionEffect.FromRight });
    }

    private void NavView_MenuItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.InvokedItemContainer is NavigationViewItem item && item.Tag is string tag)
        {
            NavigateToTag(tag);
        }
    }

    private void NavFooterButton_Click(object sender, RoutedEventArgs e)
    {
        NavigateToTag("Settings");
    }

    private void NavigateToTag(string tag)
    {
        Type? pageType = tag switch
        {
            "Survey" => typeof(Pages.SurveyPage),
            "Flashcards" => typeof(Pages.FlashcardsPage),
            "DragDrop" => typeof(Pages.DragDropPage),
            "StepGuide" => typeof(Pages.StepGuidePage),
            "Matching" => typeof(Pages.MatchingPage),
            "Sorting" => typeof(Pages.SortingPage),
            "Settings" => typeof(Pages.SettingsPage),
            _ => typeof(Pages.SurveyPage)
        };

        if (ContentFrame.CurrentSourcePageType != pageType)
        {
            ContentFrame.Navigate(pageType, null, new Microsoft.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
        }
    }

    private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
        throw new Exception($"Failed to load Page {e.SourcePageType.FullName}");
    }
}
