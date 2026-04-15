using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using LoFiLearn.Core.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage.Pickers;
using Windows.Storage;
using WinRT.Interop;

namespace LoFiLearn.App.Services;

public sealed class DocumentService
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public DocumentData CurrentDocument { get; private set; } = new DocumentData();

    public void NewDocument()
    {
        CurrentDocument = new DocumentData();
    }

    public async Task SaveDocumentAsync(Window window)
    {
        var picker = new FileSavePicker();
        picker.FileTypeChoices.Add("LoFiLearn Document", new List<string> { ".lofilearn" });
        picker.SuggestedFileName = "MyStudySession.lofilearn";
        InitializePicker(window, picker);

        var file = await picker.PickSaveFileAsync();
        if (file == null) return;

        var json = JsonSerializer.Serialize(CurrentDocument, _options);
        await FileIO.WriteTextAsync(file, json);
    }

    public async Task OpenDocumentAsync(Window window)
    {
        var picker = new FileOpenPicker();
        picker.FileTypeFilter.Add(".lofilearn");
        InitializePicker(window, picker);

        var file = await picker.PickSingleFileAsync();
        if (file == null) return;

        var content = await FileIO.ReadTextAsync(file);
        CurrentDocument = JsonSerializer.Deserialize<DocumentData>(content, _options) ?? new DocumentData();
    }

    private static void InitializePicker(Window window, object picker)
    {
        var hwnd = WindowNative.GetWindowHandle(window);
        InitializeWithWindow.Initialize(picker, hwnd);
    }
}
