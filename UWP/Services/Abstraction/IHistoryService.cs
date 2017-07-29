using System.Threading.Tasks;
using System.Collections.Generic;

using UWP.Models;

namespace UWP.Services.Abstraction
{
    public interface IHistoryService
    {
        Task<List<HistoryEntry>> GetHistoryAsync();
    }
}