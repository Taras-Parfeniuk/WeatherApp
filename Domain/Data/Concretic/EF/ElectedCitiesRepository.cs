using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities.Location;
using Domain.Data.Abstraction;
using System.Data.Entity;

namespace Domain.Data.Concretic.EF
{
    public class ElectedCitiesRepository : BaseRepository<City>, ICitiesRepository
    {
        public ElectedCitiesRepository()
        {
            Items = _context.ElectedCities;
        }

        public override void Update(City entity)
        {
            var item = Items.FirstOrDefault(e => e.Id == entity.Id);

            if(item == null)
            {
                Items.Add(entity);
            }
            else
            {
                item.Coordinates = entity.Coordinates;
                item.Country = entity.Country;
                item.Name = entity.Name;

                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
