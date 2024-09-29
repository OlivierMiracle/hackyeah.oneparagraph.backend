using AiPrompter.Runtime.Models;
using AiPrompter.Runtime.Services.Interfaces;
using Azure.AI.OpenAI;
using OneParagraph.Shared.Content;
using OneParagraph.Shared.Enums;
using OpenAI.Chat;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AiPrompter.Runtime.Services;

public class AiServiceContext(AzureOpenAIClient openAIClient) : IAiServiceContext
{
    private readonly string SystemPropmt = "You are an AI assistant responsible for summarizing stock market news for a mobile app. Your task is to condense relevant information about stocks, market trends, and key financial news into a single, concise paragraph. Make sure the summary is clear, informative, and easy to understand, avoiding technical jargon. Focus on delivering key insights such as major stock movements, market fluctuations, economic events, or company announcements that could impact the market. The summary should be no longer than 3-4 sentences, providing users with a quick yet comprehensive snapshot of the latest stock market activity. You must not, under any circumstances, fabricate or include fictional information. Only provide facts based on the provided data.";

    public async Task<List<(Industries, string)>> PromptAi(Dictionary<Industries, List<MarketauxGetNewsByCategoryResponse>> newsFromApi)
    {
        var news = new Dictionary<Industries, string>();

        foreach (var industry in newsFromApi) 
        {
            string str = "";

            foreach (var entity in industry.Value) 
            {
                foreach (var itemData in entity.Data)
                {
                    str = itemData.Title + "\n"
                        + itemData.Description + "\n"
                        + itemData.Snippet + "\n";

                    if (itemData.Entities.Count > 0)
                    {
                        foreach (var entityItem in itemData.Entities)
                        {
                            str += "Company/Entity: ";
                            str += entityItem.Name;
                            str += "\n";

                            if (itemData.Entities[0].Highlights.Count > 0)
                            {
                                foreach (var highlightItem in itemData.Entities[0].Highlights)
                                {
                                    str += "Highlights about the entity: ";
                                    str += highlightItem.HighlightText;
                                    str += "\n";
                                }
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(str))
                    news[industry.Key] = str;
            }            
        }

        var result = new List<(Industries, string)>();
        int tokensIn = 0;
        int tokensOut = 0;

        foreach (var summarizedNews in news)
        {
            var messages = new List<ChatMessage>
            {
                new SystemChatMessage(SystemPropmt),
                new UserChatMessage(summarizedNews.Value)
            };

            var chatClient = openAIClient.GetChatClient("gpt-4o-mini");
            var options = new ChatCompletionOptions() { };

            var response = await chatClient.CompleteChatAsync(messages, options);

            tokensIn += response.Value.Usage.InputTokenCount;
            tokensOut += response.Value.Usage.OutputTokenCount;
            var tokensOutDetails = response.Value.Usage.OutputTokenDetails;

            result.Add((summarizedNews.Key ,response.Value.Content[0].Text));
        }

        return result;
    }

    public async Task<List<(Stock, string)>> PromptAiFormStock(Dictionary<Stock, List<MarketauxGetNewsByCategoryResponse>> newsFromApi)
    {
        var news = new Dictionary<Stock, string>();

        foreach (var industry in newsFromApi)
        {
            string str = "";

            foreach (var entity in industry.Value)
            {
                foreach (var itemData in entity.Data)
                {
                    str = itemData.Title + "\n"
                        + itemData.Description + "\n"
                        + itemData.Snippet + "\n";

                    if (itemData.Entities.Count > 0)
                    {
                        foreach (var entityItem in itemData.Entities)
                        {
                            str += "Company/Entity: ";
                            str += entityItem.Name;
                            str += "\n";

                            if (itemData.Entities[0].Highlights.Count > 0)
                            {
                                foreach (var highlightItem in itemData.Entities[0].Highlights)
                                {
                                    str += "Highlights about the entity: ";
                                    str += highlightItem.HighlightText;
                                    str += "\n";
                                }
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(str))
                    news[industry.Key] = str;
            }
        }

        var result = new List<(Stock, string)>();
        int tokensIn = 0;
        int tokensOut = 0;

        foreach (var summarizedNews in news)
        {
            var messages = new List<ChatMessage>
            {
                new SystemChatMessage(SystemPropmt),
                new UserChatMessage(summarizedNews.Value)
            };

            var chatClient = openAIClient.GetChatClient("gpt-4o-mini");
            var options = new ChatCompletionOptions() { };

            var response = await chatClient.CompleteChatAsync(messages, options);

            tokensIn += response.Value.Usage.InputTokenCount;
            tokensOut += response.Value.Usage.OutputTokenCount;
            var tokensOutDetails = response.Value.Usage.OutputTokenDetails;

            result.Add((summarizedNews.Key, response.Value.Content[0].Text));
        }

        return result;
    }
}
