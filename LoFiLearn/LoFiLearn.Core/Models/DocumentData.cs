using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LoFiLearn.Core.Models;

public class DocumentData
{
    [JsonPropertyName("surveyData")]
    public List<SurveyItem> SurveyData { get; set; } = new();

    [JsonPropertyName("flashcardsData")]
    public List<FlashcardItem> FlashcardsData { get; set; } = new();

    [JsonPropertyName("dragDropData")]
    public List<DragDropItem> DragDropData { get; set; } = new();

    [JsonPropertyName("stepGuideData")]
    public List<StepGuideItem> StepGuideData { get; set; } = new();

    [JsonPropertyName("matchingData")]
    public List<MatchingItem> MatchingData { get; set; } = new();

    [JsonPropertyName("sortingData")]
    public List<SortingItem> SortingData { get; set; } = new();

    [JsonPropertyName("embeddedAssets")]
    public Dictionary<string, string> EmbeddedAssets { get; set; } = new();
}

public class SurveyItem
{
    [JsonPropertyName("id")] public string Id { get; set; } = Guid.NewGuid().ToString();
    [JsonPropertyName("prompt")] public string Prompt { get; set; } = string.Empty;
    [JsonPropertyName("answer")] public string Answer { get; set; } = string.Empty;
    [JsonPropertyName("assetId")] public string? AssetId { get; set; }
}

public class FlashcardItem
{
    [JsonPropertyName("id")] public string Id { get; set; } = Guid.NewGuid().ToString();
    [JsonPropertyName("front")] public string Front { get; set; } = string.Empty;
    [JsonPropertyName("back")] public string Back { get; set; } = string.Empty;
    [JsonPropertyName("assetId")] public string? AssetId { get; set; }
}

public class DragDropItem
{
    [JsonPropertyName("id")] public string Id { get; set; } = Guid.NewGuid().ToString();
    [JsonPropertyName("question")] public string Question { get; set; } = string.Empty;
    [JsonPropertyName("options")] public List<string> Options { get; set; } = new();
    [JsonPropertyName("correctOrder")] public List<string> CorrectOrder { get; set; } = new();
}

public class StepGuideItem
{
    [JsonPropertyName("id")] public string Id { get; set; } = Guid.NewGuid().ToString();
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    [JsonPropertyName("steps")] public List<string> Steps { get; set; } = new();
}

public class MatchingItem
{
    [JsonPropertyName("id")] public string Id { get; set; } = Guid.NewGuid().ToString();
    [JsonPropertyName("pairs")] public Dictionary<string, string> Pairs { get; set; } = new();
}

public class SortingItem
{
    [JsonPropertyName("id")] public string Id { get; set; } = Guid.NewGuid().ToString();
    [JsonPropertyName("label")] public string Label { get; set; } = string.Empty;
    [JsonPropertyName("items")] public List<string> Items { get; set; } = new();
    [JsonPropertyName("targetOrder")] public List<string> TargetOrder { get; set; } = new();
}
