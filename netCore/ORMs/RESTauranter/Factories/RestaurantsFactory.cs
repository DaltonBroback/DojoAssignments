using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using RESTauranter.Models;

namespace RESTauranter.Factory
{
    public class RestaurantsFactory : IFactory<Restaurants>
    {
        private string connectionString;
        public RestaurantsFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=mydb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(Restaurants item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "Insert INTO restaurants (name, created_at, updated_at) VALUES (@Name, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public int FindLastId()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT id FROM restaurants ORDER BY updated_at DESC LIMIT 1";
                dbConnection.Open();
                return System.Convert.ToInt32(dbConnection.ExecuteScalar(query));
            }
        }
        public int FindId(Restaurants item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT id FROM restaurants WHERE name = @Name";
                dbConnection.Open();
                return System.Convert.ToInt32(dbConnection.ExecuteScalar(query));
            }
        }
        public int FindIdByName(string Name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT id FROM restaurants WHERE name = "+Name+" LIMIT 1";
                dbConnection.Open();
                return System.Convert.ToInt32(dbConnection.ExecuteScalar(query));
            }
        }
        public IEnumerable<Restaurants> FindByName(string Name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM restaurants WHERE name = "+Name+";";
                dbConnection.Open();
                return dbConnection.Query<Restaurants>(query);
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