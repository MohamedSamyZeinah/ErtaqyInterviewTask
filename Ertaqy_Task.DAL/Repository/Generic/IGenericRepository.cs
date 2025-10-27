using System.Data;

namespace Ertaqy_Task.DAL.Repository.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        public DataTable GetAll();
        public int Insert(T entity);
    }
}
