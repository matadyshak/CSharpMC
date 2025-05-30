using SQLServerUI.Models;

namespace DataAccessLibrary
{
    public class SqlCrud
    {
        private readonly string _connectionString;

        private SqlDataAccess db = new SqlDataAccess();

        public SqlCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BasicContactModel> GetAllContacts()
        {
            string sql = "select Id, GivenName, SurName from dbo.Contacts;";
            return db.LoadData<BasicContactModel, dynamic>(sql, new { }, _connectionString);
        }
    }
}
