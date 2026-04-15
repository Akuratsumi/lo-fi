using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoFiLearn.Core.Models;
using LoFiLearn.App.Services;
using System.Collections.ObjectModel;

namespace LoFiLearn.App.ViewModels;

public sealed partial class MatchingViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    public MatchingViewModel(DocumentService documentService)
    {
        _documentService = documentService;
        MatchingItems = new ObservableCollection<MatchingItem>(_documentService.CurrentDocument.MatchingData);
    }

    public ObservableCollection<MatchingItem> MatchingItems { get; }

    [RelayCommand]
    public void AddSet()
    {
        var item = new MatchingItem
        {
            Pairs = new Dictionary<string, string>
            {
                ["A"] = "1",
                ["B"] = "2"
            }
        };
        MatchingItems.Add(item);
        _documentService.CurrentDocument.MatchingData.Add(item);
    }

    [RelayCommand]
    public void RemoveSet(MatchingItem item)
    {
        if (item == null) return;
        MatchingItems.Remove(item);
        _documentService.CurrentDocument.MatchingData.Remove(item);
    }
}
