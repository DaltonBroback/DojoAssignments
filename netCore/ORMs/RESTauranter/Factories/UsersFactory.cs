using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using RESTauranter.Models;

namespace RESTauranter.Factory
{
    public class UsersFactory : IFactory<Users>
    {
        private string connectionString;
        public UsersFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=mydb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(Users item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "Insert INTO users (name, created_at, updated_at) VALUES (@Name, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public int FindLastId()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT id FROM users ORDER BY updated_at DESC LIMIT 1";
                dbConnection.Open();
                return System.Convert.ToInt32(dbConnection.ExecuteScalar(query));
            }
        }
        public int FindId(Users item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT id FROM users WHERE name = @Name";
                dbConnection.Open();
                return System.Convert.ToInt32(dbConnection.ExecuteScalar(query));
            }
        }
        public IEnumerable<Users> FindByName(string Name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM users WHERE name = "+Name+" LIMIT 1";
                dbConnection.Open();
                return dbConnection.Query<Users>(query);
            }
        }
        public IEnumerable<Users> FindById(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM users WHERE id = "+Id+" LIMIT 1";
                dbConnection.Open();
                return dbConnection.Query<Users>(query);
            }
        }
        public int FindIdByName(string Name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT id FROM users WHERE name = '"+Name+"' LIMIT 1";
                dbConnection.Open();
                return System.Convert.ToInt32(dbConnection.ExecuteScalar(query));
            }
        }
        public bool SearchForName(string Name)
        {
            if(FindIdByName(Name) <= 0){
                return true;
            }
            return false;
        }
    }
}