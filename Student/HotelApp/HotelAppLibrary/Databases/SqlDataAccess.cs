using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

// Dapper is for Query and Execute methods
// Microsoft.Data.SqlClient is for SqlConnection
// System.Data is for IDbConnection and CommandType
// Microsoft.Extensions.Configuration is for IConfiguration

namespace HotelAppLibrary.Databases
{
    public class SqlDataAccess : ISqlDataAccess
    {
        // using at Top-level  => Brings namespaces into scope so you can use their classes
        // using inside-method => Ensures proper disposal of objects implementing IDisposable

        private readonly IConfiguration _config;

        // this is called at beginning of program for dependency injection
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public List<T> LoadData<T, U>(string sqlStatement,
                                      U parameters,
                                      string connectionStringName,
                                      bool isStoredProcedure = false)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            CommandType commandType = CommandType.Text;

            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                // named parameter syntax is used here
                // The first 'commandType:' sets which parameter is being set
                // The second 'commandType' is the value
                // This is a way to skip over parameters that you don't want to set but take the default value

                // Dapper will automatically map the SQL parameters to the properties of the parameters object
                List<T> rows = connection.Query<T>(sqlStatement, parameters, commandType: commandType).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string sqlStatement,
                                T parameters,
                                string connectionStringName,
                                bool isStoredProcedure = false)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            CommandType commandType = CommandType.Text;

            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                // Dapper will automatically map the properties of the parameters object to the SQL parameters
                connection.Execute(sqlStatement, parameters, commandType: commandType);
            }
        }
    }
}
