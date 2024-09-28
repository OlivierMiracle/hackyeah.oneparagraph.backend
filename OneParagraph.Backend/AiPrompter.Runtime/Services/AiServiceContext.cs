using AiPrompter.Runtime.Models;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AiPrompter.Runtime.Services;

public class AiServiceContext(AzureOpenAIClient openAIClient)
{
    private readonly string SystemPropmt = "";

    public async Task<string> PromptAi(List<MarketauxGetNewsByCategoryResponse> newsFromApi, string deploymentName)
    {
        //var messages = new List<ChatMessage>
        //{
        //    new SystemChatMessage(SystemPropmt),
        //    new UserChatMessage(command.UserMessage)
        //};

        var chatClient = openAIClient.GetChatClient(deploymentName);
        var options = new ChatCompletionOptions()
        {
            // MaxOutputTokenCount = 500,
        };

        //var response = await chatClient.CompleteChatAsync(messages, options);

        //return response.Value.Content[0].Text;

        throw new NotImplementedException();
    }
}
