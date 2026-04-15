using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;
using LoFiLearn.App.ViewModels;

namespace LoFiLearn.App.Pages;

public sealed partial class DragDropPage : Page
{
    public DragDropViewModel ViewModel { get; }

    public DragDropPage()
    {
        InitializeComponent();
        ViewModel = App.Services.GetRequiredService<DragDropViewModel>();
        DataContext = this;
    }
}
