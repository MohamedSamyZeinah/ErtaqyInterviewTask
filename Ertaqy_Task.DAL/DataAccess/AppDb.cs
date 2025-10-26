using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Ertaqy_Task.DAL.DataAccess
{
    public class AppDb(IConfiguration configuration)
    {
        private readonly string _dbConnectionString = configuration.GetConnectionString("CS");

        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection conn = new(_dbConnectionString))
            {
                SqlCommand Query = new(query, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Query);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
        }

        public DataRow ExecuteQueryScalar(string query)
        {
            using (SqlConnection conn = new(_dbConnectionString))
            {
                SqlCommand Query = new(query, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Query);

                DataTable dt = new();
                dataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;
            }
        }

        public int ExecuteCommand(string command)
        {
            using (SqlConnection conn = new SqlConnection(_dbConnectionString))
            using (SqlCommand cmd = new SqlCommand(command, conn))
            {
                //if (parameters != null)
                //{
                //    foreach (var param in parameters)
                //        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                //}

                conn.Open();
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows;
            }

        }
    }
}
