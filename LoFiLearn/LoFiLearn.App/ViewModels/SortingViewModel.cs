using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoFiLearn.Core.Models;
using LoFiLearn.App.Services;
using System.Collections.ObjectModel;

namespace LoFiLearn.App.ViewModels;

public sealed partial class SortingViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    public SortingViewModel(DocumentService documentService)
    {
        _documentService = documentService;
        SortingItems = new ObservableCollection<SortingItem>(_documentService.CurrentDocument.SortingData);
    }

    public ObservableCollection<SortingItem> SortingItems { get; }

    [RelayCommand]
    public void AddBatch()
    {
        var item = new SortingItem
        {
            Label = "Sort this deck",
            Items = new List<string> { "One", "Two", "Three" },
            TargetOrder = new List<string> { "One", "Two", "Three" }
        };
        SortingItems.Add(item);
        _documentService.CurrentDocument.SortingData.Add(item);
    }

    [RelayCommand]
    public void RemoveBatch(SortingItem item)
    {
        if (item == null) return;
        SortingItems.Remove(item);
        _documentService.CurrentDocument.SortingData.Remove(item);
    }
}
