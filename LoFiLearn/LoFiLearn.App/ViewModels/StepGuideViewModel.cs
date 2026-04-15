using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoFiLearn.Core.Models;
using LoFiLearn.App.Services;
using System.Collections.ObjectModel;

namespace LoFiLearn.App.ViewModels;

public sealed partial class StepGuideViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    public StepGuideViewModel(DocumentService documentService)
    {
        _documentService = documentService;
        StepGuides = new ObservableCollection<StepGuideItem>(_documentService.CurrentDocument.StepGuideData);
    }

    public ObservableCollection<StepGuideItem> StepGuides { get; }

    [RelayCommand]
    public void AddGuide()
    {
        var guide = new StepGuideItem { Title = "New walkthrough", Steps = new List<string> { "Step one", "Step two" } };
        StepGuides.Add(guide);
        _documentService.CurrentDocument.StepGuideData.Add(guide);
    }

    [RelayCommand]
    public void RemoveGuide(StepGuideItem guide)
    {
        if (guide == null) return;
        StepGuides.Remove(guide);
        _documentService.CurrentDocument.StepGuideData.Remove(guide);
    }
}
