using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Domain.Data.Abstraction;
using Domain.Entities.Location;

namespace Domain.Data.Concretic.EF
{
    public class CitiesRepository : BaseRepository<City>, ICitiesRepository
    {
        public CitiesRepository()
        {
            Items = _context.Cities;
        }

        public override void Update(City entity)
        {
            var item = Items.FirstOrDefault(e => e.Id == entity.Id);

            if (item == null)
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
