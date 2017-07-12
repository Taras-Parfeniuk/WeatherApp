using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities.Location;

namespace Domain.Data.Abstraction
{
    public interface ISelectedCitiesRepository : IRepository<SelectedCity>
    {
        void Remove(int id);
        
    }
}
