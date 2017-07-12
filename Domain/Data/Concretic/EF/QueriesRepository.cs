using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Domain.Data.Abstraction;
using Domain.Entities;

namespace Domain.Data.Concretic.EF
{
    public class QueriesRepository : BaseRepository<ForecastQueryInfo>, IQueriesRepository
    {
        public QueriesRepository()
        {
            Items = _context.Set<ForecastQueryInfo>();
        }

        public IEnumerable<ForecastQueryInfo> GetByCityId(int id)
        {
            return Items.Where(q => q.City.Id == id);
        }

        public IEnumerable<ForecastQueryInfo> GetByCityName(string name)
        {
            return Items.Where(q => q.City.Name == name);
        }

        public override List<ForecastQueryInfo> GetAll()
        {
            _context.Forecasts.Load();
            return base.GetAll();
        }

        public override void AddOrUpdate(ForecastQueryInfo entity)
        {
            var item = Items.FirstOrDefault(e => e.Id == entity.Id);

            if (item == null)
            {
                Items.Add(entity);
            }
            else
            {
                item.City = entity.City;
                item.Forecasts = entity.Forecasts;
                item.QueryTime = entity.QueryTime;

                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}
