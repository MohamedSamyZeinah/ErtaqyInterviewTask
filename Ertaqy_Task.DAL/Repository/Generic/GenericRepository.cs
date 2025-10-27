using Ertaqy_Task.DAL.DataAccess;
using System.Data;

namespace Ertaqy_Task.DAL.Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Fields
        private readonly AppDb _appDb;
        #endregion

        #region Constructor
        public GenericRepository(AppDb appDb)
        {
            _appDb = appDb;
        }
        #endregion


        //public int Delete(int id)
        //{
        //    string tableName = typeof(T).Name + "S";
        //    string command = $"Delete from {tableName} where Id=@{id}";
        //    return _appDb.ExecuteCommand(command);
        //}

        #region Methods
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
            string tableName = typeof(T).Name + "s";


            var properties = typeof(T).GetProperties()
                .Where(p => p.Name.ToLower() != "id")
                .ToList();


            string columns = string.Join(", ", properties.Select(p => p.Name));


            string parameters = string.Join(", ", properties.Select(p => "@" + p.Name));


            string command = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

            var paramDict = new Dictionary<string, object>();
            foreach (var prop in properties)
            {
                var value = prop.GetValue(entity) ?? DBNull.Value;
                paramDict.Add("@" + prop.Name, value);
            }

            return _appDb.ExecuteCommand(command, paramDict);
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
