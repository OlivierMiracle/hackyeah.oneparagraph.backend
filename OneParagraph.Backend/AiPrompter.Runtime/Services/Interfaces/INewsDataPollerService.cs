using System.Threading.Tasks;

namespace AiPrompter.Runtime.Services.Interfaces;

public interface INewsDataPollerService
{
    Task GetNewsDataAsync();
}
