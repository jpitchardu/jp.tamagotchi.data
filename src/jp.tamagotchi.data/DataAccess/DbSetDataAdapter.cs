using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace jp.tamagotchi.data.DataAccess
{
    internal class DbSetDataAdapter<T> : IDataCollectionAdapter<T> where T : class
    {

        private DbSet<T> _dbSet;

        public DbSetDataAdapter(DbSet<T> dbSet)
        {
            this._dbSet = dbSet;
        }

        public IQueryable<T> GetAll() => _dbSet;

        public T GetSingle(Func<T, bool> predicate) => _dbSet.FirstOrDefault(predicate);

        public T Add(T t) => _dbSet.Add(t).Entity;

        public T Update(T t, Func<T, bool> predicate = null) => _dbSet.Update(t).Entity;

        public void Delete(Func<T, bool> predicate)
        {
            var entity = _dbSet.FirstOrDefault(predicate);

            if (entity != null) _dbSet.Remove(entity);
        }
    }
}