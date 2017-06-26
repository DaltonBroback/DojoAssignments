using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using RESTauranter.Models;

namespace RESTauranter.Factory
{
    public class ReviewsFactory : IFactory<Reviews>
    {
        private string connectionString;
        public ReviewsFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=mydb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(Reviews item, int userid, int restaurantid)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "Insert INTO Reviews (`content`, `date`, `rating`, `created_at`, `updated_at`, `User_id`, `Restaurant_id`) VALUES (@Content, @Date, @Rating, NOW(), NOW(),"+userid+", "+restaurantid+")";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
    }
}