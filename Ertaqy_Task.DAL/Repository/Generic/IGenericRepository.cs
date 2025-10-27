using System.Data;

namespace Ertaqy_Task.DAL.Repository.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        public DataTable GetAll();
        public DataRow GetById(int id);
        public int Insert(T entity);
        public int Update(T entity);
        //public int Delete(int id);
    }
}
