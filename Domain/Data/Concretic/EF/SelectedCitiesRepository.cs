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
    public class SelectedCitiesRepository : BaseRepository<SelectedCity>, ISelectedCitiesRepository
    {
        public SelectedCitiesRepository()
        {
            Items = _context.SelectedCities;
        }

        public void Remove(int id)
        {
            var item = Items.FirstOrDefault(c => c.Id == id);
            if (item != null)
                Remove(item);
        }

        public override void AddOrUpdate(SelectedCity entity)
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
            }
            _context.SaveChanges();
        }
    }
}
