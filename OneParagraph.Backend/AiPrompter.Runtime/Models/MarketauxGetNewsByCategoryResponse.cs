using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace AiPrompter.Runtime.Models;

public class MarketauxGetNewsByCategoryResponse
{
    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("data")]
    public List<NewsData> Data { get; set; }
}

public class Meta
{
    [JsonPropertyName("found")]
    public int Found { get; set; }

    [JsonPropertyName("returned")]
    public int Returned { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }
}

public class NewsData
{
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("keywords")]
    public string Keywords { get; set; }

    [JsonPropertyName("snippet")]
    public string Snippet { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("published_at")]
    public string PublishedAt { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("relevance_score")]
    public double? RelevanceScore { get; set; }

    [JsonPropertyName("entities")]
    public List<Entity> Entities { get; set; }

    [JsonPropertyName("similar")]
    public List<SimilarNews> Similar { get; set; }
}

public class Entity
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("exchange")]
    public string Exchange { get; set; }

    [JsonPropertyName("exchange_long")]
    public string ExchangeLong { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("industry")]
    public string Industry { get; set; }

    [JsonPropertyName("match_score")]
    public double? MatchScore { get; set; }

    [JsonPropertyName("sentiment_score")]
    public double? SentimentScore { get; set; }

    [JsonPropertyName("highlights")]
    public List<Highlight> Highlights { get; set; }
}

public class Highlight
{
    [JsonPropertyName("highlight")]
    public string HighlightText { get; set; }

    [JsonPropertyName("sentiment")]
    public double? Sentiment { get; set; }

    [JsonPropertyName("highlighted_in")]
    public string HighlightedIn { get; set; }
}

public class SimilarNews
{
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("keywords")]
    public string Keywords { get; set; }
    [JsonPropertyName("snippet")]
    public string Snippet { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }
    [JsonPropertyName("language")]
    public string Language { get; set; }
    [JsonPropertyName("published_at")]
    public string PublishedAt { get; set; }
    [JsonPropertyName("source")]
    public string Source { get; set; }
    [JsonPropertyName("relevance_score")]
    public double? RelevanceScore { get; set; }
    [JsonPropertyName("entities")]
    public List<Entity> Entities { get; set; }
}
