using ClinicAppointmentApp.DbManager;
using ClinicAppointmentApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicAppointmentApp.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ClinicTestEntities _context = null;
        public DbSet<T> table = null;
        public GenericRepository()
        {
            _context = new ClinicTestEntities();
            table = _context.Set<T>();
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
