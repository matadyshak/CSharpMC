using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAccessLibrary
{
    public class SqlDataAccess
    {
        public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
        {
            // using at Top-level  => Brings namespaces into scope so you can use their classes
            // using inside-method => Ensures proper disposal of objects implementing IDisposable

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
