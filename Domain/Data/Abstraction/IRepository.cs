﻿using System.Collections.Generic;

namespace Domain.Data.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}