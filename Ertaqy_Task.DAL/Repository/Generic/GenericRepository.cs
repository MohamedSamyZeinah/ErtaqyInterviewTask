using Ertaqy_Task.DAL.DataAccess;
using System.Data;

namespace Ertaqy_Task.DAL.Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDb _appDb;

        public GenericRepository(AppDb appDb)
        {
            _appDb = appDb;
        }
        public int Delete(int id)
        {
            string tableName = typeof(T).Name + "S";
            string command = $"Delete from {tableName} where Id=@{id}";
            return _appDb.ExecuteCommand(command);
        }

        public DataTable GetAll()
        {
            string tableName = typeof(T).Name + "S";
            string query = $"select * from {tableName}";
            return _appDb.ExecuteQuery(query);
        }

        public DataRow GetById(int id)
        {
            string tableName = typeof(T).Name + "S";
            string query = $"select * from {tableName} where Id=@{id}";
            return _appDb.ExecuteQueryScalar(query);
        }

        public int Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
