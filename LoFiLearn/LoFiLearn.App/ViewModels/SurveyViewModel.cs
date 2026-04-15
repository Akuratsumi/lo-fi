using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoFiLearn.Core.Models;
using LoFiLearn.App.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace LoFiLearn.App.ViewModels;

public sealed partial class SurveyViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    public SurveyViewModel(DocumentService documentService)
    {
        _documentService = documentService;
        SurveyItems = new ObservableCollection<SurveyItem>(_documentService.CurrentDocument.SurveyData);
    }

    public ObservableCollection<SurveyItem> SurveyItems { get; }

    [RelayCommand]
    public void AddItem()
    {
        var item = new SurveyItem { Prompt = "New prompt", Answer = "New answer" };
        SurveyItems.Add(item);
        _documentService.CurrentDocument.SurveyData.Add(item);
    }

    [RelayCommand]
    public void RemoveItem(SurveyItem item)
    {
        if (item == null) return;
        SurveyItems.Remove(item);
        _documentService.CurrentDocument.SurveyData.Remove(item);
    }
}
