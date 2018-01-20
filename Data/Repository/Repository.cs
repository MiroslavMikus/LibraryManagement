using LibraryManagement.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected readonly LibraryDbContext _context;
        public Repository(LibraryDbContext context)
        {
            _context = context;
        }
        protected void Save() => _context.SaveChanges();

        public void Create(T entity)
        {
            _context.Add(entity);

            Save();
        }

        public virtual void Delete(T entity)
        {
            _context.Remove(entity);

            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public int Count(Func<T, Boolean> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public bool Any(Func<T, bool> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public bool Any()
        {
            return _context.Set<T>().Any();
        }
    }
}
