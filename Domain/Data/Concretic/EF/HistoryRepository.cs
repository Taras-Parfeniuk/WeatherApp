using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data.Abstraction;
using Domain.Entities.Concretic;
using Domain.Exceptions;

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

        public override void Update(HistoryEntry entity)
        {
            var item = Items.FirstOrDefault(e => e.Id == entity.Id);

            if (item == null)
            {
                throw new ItemNotExistException($"City with id: {entity.Id} not found");
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

        public override async Task<List<HistoryEntry>> GetAllAsync()
        {
            await _context.Forecasts.LoadAsync();
            return await base.GetAllAsync();
        }

        public override async Task UpdateAsync(HistoryEntry entity)
        {
            var item = await Items.FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (item == null)
            {
                throw new ItemNotExistException($"City with id: {entity.Id} not found");
            }
            else
            {
                item.CityId = entity.CityId;
                item.Forecasts = entity.Forecasts;
                item.Time = entity.Time;

                _context.Entry(item).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }

        public override async Task AddOrUpdateAsync(HistoryEntry entity)
        {
            var item = await Items.FirstOrDefaultAsync(e => e.Id == entity.Id);

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
            await _context.SaveChangesAsync();
        }

        public HistoryEntry GetById(Guid id)
        {
            _context.Forecasts.Load();
            return Items.FirstOrDefault(e => e.Id == id);
        }

        public async Task<IEnumerable<HistoryEntry>> GetByCityIdAsync(int id)
        {
            return await Items.Where(q => q.CityId == id).ToListAsync();
        }

        public async Task<HistoryEntry> GetByIdAsync(Guid id)
        {
            await _context.Forecasts.LoadAsync();
            return await Items.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
