using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;
using LoFiLearn.App.ViewModels;

namespace LoFiLearn.App.Pages;

public sealed partial class MatchingPage : Page
{
    public MatchingViewModel ViewModel { get; }

    public MatchingPage()
    {
        InitializeComponent();
        ViewModel = App.Services.GetRequiredService<MatchingViewModel>();
        DataContext = this;
    }
}
