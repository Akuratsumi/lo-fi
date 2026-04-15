using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoFiLearn.Core.Models;
using LoFiLearn.App.Services;
using System.Collections.ObjectModel;

namespace LoFiLearn.App.ViewModels;

public sealed partial class DragDropViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    public DragDropViewModel(DocumentService documentService)
    {
        _documentService = documentService;
        DragDropItems = new ObservableCollection<DragDropItem>(_documentService.CurrentDocument.DragDropData);
    }

    public ObservableCollection<DragDropItem> DragDropItems { get; }

    [RelayCommand]
    public void AddTask()
    {
        var item = new DragDropItem
        {
            Question = "Arrange these steps",
            Options = new List<string> { "First", "Middle", "Last" },
            CorrectOrder = new List<string> { "First", "Middle", "Last" }
        };
        DragDropItems.Add(item);
        _documentService.CurrentDocument.DragDropData.Add(item);
    }

    [RelayCommand]
    public void RemoveTask(DragDropItem item)
    {
        if (item == null) return;
        DragDropItems.Remove(item);
        _documentService.CurrentDocument.DragDropData.Remove(item);
    }
}
