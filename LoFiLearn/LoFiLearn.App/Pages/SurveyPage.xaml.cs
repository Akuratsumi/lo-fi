using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using LoFiLearn.App.ViewModels;

namespace LoFiLearn.App.Pages;

public sealed partial class SurveyPage : Page
{
    public SurveyViewModel ViewModel { get; }

    public SurveyPage()
    {
        InitializeComponent();
        ViewModel = App.Services.GetRequiredService<SurveyViewModel>();
        DataContext = this;
    }
}
