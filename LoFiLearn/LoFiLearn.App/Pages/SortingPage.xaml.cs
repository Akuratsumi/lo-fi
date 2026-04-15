using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;
using LoFiLearn.App.ViewModels;

namespace LoFiLearn.App.Pages;

public sealed partial class SortingPage : Page
{
    public SortingViewModel ViewModel { get; }

    public SortingPage()
    {
        InitializeComponent();
        ViewModel = App.Services.GetRequiredService<SortingViewModel>();
        DataContext = this;
    }
}
