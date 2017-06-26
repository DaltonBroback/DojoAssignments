using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using lostinthewoods.Models;
 
namespace lostinthewoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=lostinthewoods;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails");
            }
        }
        public IEnumerable<Trail> GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = "+id+" LIMIT 1;");
            }
        }
        public void Add(Trail item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO `lostinthewoods`.`trails` (`name`, `description`, `length`, `elevationchange`, `longitude`, `logdir`, `latitude`, `latdir`, `created_at`, `updated_at`) VALUES (@Name, @Description, @Length, @ElevationChange, @Longitude, @NorS, @Latitude , @EorW, NOW(), NOW());";
                dbConnection.Open();
                dbConnection.Execute(query,item);
            }
        }


        // public IEnumerable<Trail> Add(string name, string desc, double length, int elchange, double longitude, string NorS, double latitude, string EorW)
        // {
        //     using (IDbConnection dbConnection = Connection)
        //     {
        //         dbConnection.Open();
        //         return dbConnection.Query<Trail>("INSERT INTO `lostinthewoods`.`trails` (`name`, `description`, `length`, `elevationchange`, `longitude`, `logdir`, `latitude`, `latdir`, `created_at`, `updated_at`) VALUES ('"+name+"', '"+desc+"', '"+length+"', '"+elchange+"', '"+longitude+"', '"+NorS+"', '"+latitude+"', '"+EorW+"', NOW(), NOW());");
        //     }
        // }
    }
}
