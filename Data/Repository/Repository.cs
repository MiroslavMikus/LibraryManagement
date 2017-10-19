using LibraryManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly LibraryDbContext _context;
        public Repository(LibraryDbContext context)
        {
            _context = context;
        }
        private void Save() => _context.SaveChanges();

        public void Create(T entity)
        {
            _context.Add(entity);

            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
