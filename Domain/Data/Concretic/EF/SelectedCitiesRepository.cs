using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Domain.Entities.Concretic;
using Domain.Data.Abstraction;
using Domain.Exceptions;

namespace Domain.Data.Concretic.EF
{
    public class SelectedCitiesRepository : BaseRepository<City>, ISelectedCitiesRepository
    {
        public SelectedCitiesRepository()
        {
            Items = _context.SelectedCities;
        }

        public void Remove(int id)
        {
            var item = Items.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                Remove(item);
            }
            else
            {
                throw new ItemNotExistException($"City with id: {id} not exist in selected");
            }
        }

        public override void Remove(City entity)
        {
            var item = Items.FirstOrDefault(c => c.Id == entity.Id);
            if (item != null)
            {
                Items.Remove(item);
                _context.SaveChanges();
            }
            else
            {
                throw new ItemNotExistException($"City with id: {entity.Id} not exist in selected");
            }
        }

        public override void Update(City entity)
        {
            var item = Items.FirstOrDefault(e => e.Id == entity.Id);

            if (item == null)
            {
                throw new ItemNotExistException($"City with id: {entity.Id} not found");
            }
            else
            {
                item.Country = entity.Country;
                item.Name = entity.Name;

                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public override void AddOrUpdate(City entity)
        {
            var item = Items.FirstOrDefault(e => e.Id == entity.Id);

            if(item == null)
            {
                Items.Add(entity);
            }
            else
            {
                item.Country = entity.Country;
                item.Name = entity.Name;

                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}
