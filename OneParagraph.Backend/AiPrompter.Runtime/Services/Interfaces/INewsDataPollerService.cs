using AiPrompter.Runtime.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AiPrompter.Runtime.Services.Interfaces;

public interface INewsDataPollerService
{
    Task<List<MarketauxGetNewsByCategoryResponse>> GetCategoryNewsAsync();
}
