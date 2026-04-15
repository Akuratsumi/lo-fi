using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using LoFiLearn.App.ViewModels;

namespace LoFiLearn.App.Pages;

public sealed partial class FlashcardsPage : Page
{
    public FlashcardsViewModel ViewModel { get; }

    public FlashcardsPage()
    {
        InitializeComponent();
        ViewModel = App.Services.GetRequiredService<FlashcardsViewModel>();
        DataContext = this;
    }
}
