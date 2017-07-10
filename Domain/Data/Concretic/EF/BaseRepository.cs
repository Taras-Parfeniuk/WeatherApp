using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Domain.Data.Abstraction;

namespace Domain.Data.Concretic.EF
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public virtual void Add(TEntity entity)
        {
            Items.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            Items.Remove(entity);
        }

        public virtual void Update(TEntity entity) { }

        protected readonly WeatherDbContext _context = new WeatherDbContext();
        protected virtual DbSet<TEntity> Items { get; set; }
    }
}
