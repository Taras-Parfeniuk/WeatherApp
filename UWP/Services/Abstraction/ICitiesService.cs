using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Models;

namespace UWP.Services.Abstraction
{
    public interface ICitiesService
    {
        Task<List<City>> GetSelectedAsync();

        Task<List<City>> GetDefaultAsync();

        Task<City> GetByIdAsync(int id);

        Task<bool> AddToSelectedAsync(City city);

        Task<bool> RemoveFromSelectedAsync(int id);
        
    }
}
