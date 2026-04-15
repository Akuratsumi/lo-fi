using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;
using LoFiLearn.App.ViewModels;

namespace LoFiLearn.App.Pages;

public sealed partial class StepGuidePage : Page
{
    public StepGuideViewModel ViewModel { get; }

    public StepGuidePage()
    {
        InitializeComponent();
        ViewModel = App.Services.GetRequiredService<StepGuideViewModel>();
        DataContext = this;
    }
}
