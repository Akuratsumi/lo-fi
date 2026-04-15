using CommunityToolkit.Mvvm.ComponentModel;

namespace LoFiLearn.App;

public sealed partial class AppSettings : ObservableObject
{
    [ObservableProperty]
    private double volume = 80;
}
