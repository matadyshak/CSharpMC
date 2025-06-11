using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLibrary
{
    public class SqlDataAccess
    {
        // using at Top-level  => Brings namespaces into scope so you can use their classes
        // using inside-method => Ensures proper disposal of objects implementing IDisposable

        public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string sqlStatement, T parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sqlStatement, parameters);
            }
        }
    }
}