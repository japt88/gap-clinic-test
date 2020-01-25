using System.Collections.Generic;

namespace ClinicAppointmentApp.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        T GetById(object id);
        IEnumerable<T> GetAll();
    }
}
