using AiPrompter.Runtime.Models;
using OneParagraph.Shared.Content;
using OneParagraph.Shared.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AiPrompter.Runtime.Services.Interfaces;

public interface INewsDataPollerService
{
    Task<Dictionary<Industry, List<MarketauxGetNewsByCategoryResponse>>> GetCategoryNewsAsync();
    Task<Dictionary<Stock, List<MarketauxGetNewsByCategoryResponse>>> GetStockNewsAsync();
}
