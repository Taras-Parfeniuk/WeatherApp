using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Domain.Data.Abstraction;
using Domain.Entities.Concretic;

namespace Domain.Data.Concretic.EF
{
    public class HistoryRepository : BaseRepository<HistoryEntry>, IHistoryRepository
    {
        public HistoryRepository()
        {
            Items = _context.Set<HistoryEntry>();
        }

        public IEnumerable<HistoryEntry> GetByCityId(int id)
        {
            return Items.Where(q => q.CityId == id);
        }

        public override List<HistoryEntry> GetAll()
        {
            _context.Forecasts.Load();
            return base.GetAll();
        }

        public override void AddOrUpdate(HistoryEntry entity)
        {
            var item = Items.FirstOrDefault(e => e.Id == entity.Id);

            if (item == null)
            {
                Items.Add(entity);
            }
            else
            {
                item.CityId = entity.CityId;
                item.Forecasts = entity.Forecasts;
                item.Time = entity.Time;

                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public HistoryEntry GetById(Guid id)
        {
            _context.Forecasts.Load();
            return Items.FirstOrDefault(e => e.Id == id);
        }
    }
}
