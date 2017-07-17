﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Domain.Exceptions;
using Domain.Data.Abstraction;

namespace Domain.Data.Concretic.EF
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public virtual void Add(TEntity entity)
        {
            try
            {
                Items.Add(entity);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new ItemAlreadyExistException("Item already exist", ex);
            }
        }

        public virtual void Update(TEntity entity) { }

        public virtual void Remove(TEntity entity)
        {
            try
            {
                Items.Remove(entity);
            _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ItemNotExistException("Item already exist", ex);
            }
        }

        public virtual void AddOrUpdate(TEntity entity) { }

        public virtual List<TEntity> GetAll()
        {
            return Items.ToList();
        }

        protected readonly WeatherDbContext _context = new WeatherDbContext();
        protected virtual DbSet<TEntity> Items { get; set; }
    }
}
