using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoFiLearn.Core.Models;
using LoFiLearn.App.Services;
using System.Collections.ObjectModel;

namespace LoFiLearn.App.ViewModels;

public sealed partial class FlashcardsViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    public FlashcardsViewModel(DocumentService documentService)
    {
        _documentService = documentService;
        Flashcards = new ObservableCollection<FlashcardItem>(_documentService.CurrentDocument.FlashcardsData);
    }

    public ObservableCollection<FlashcardItem> Flashcards { get; }

    [RelayCommand]
    public void AddCard()
    {
        var card = new FlashcardItem { Front = "Question", Back = "Answer" };
        Flashcards.Add(card);
        _documentService.CurrentDocument.FlashcardsData.Add(card);
    }

    [RelayCommand]
    public void RemoveCard(FlashcardItem card)
    {
        if (card == null) return;
        Flashcards.Remove(card);
        _documentService.CurrentDocument.FlashcardsData.Remove(card);
    }
}
