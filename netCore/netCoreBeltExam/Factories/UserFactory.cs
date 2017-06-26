using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using netCoreBeltExam.Models;
using System;

namespace netCoreBeltExam.Factory
{
    public class UserFactory : IFactory<User>
    {
        private string connectionString;
        public UserFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=beltexam;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(User item)
        {
            using (IDbConnection dbConnection = Connection){
                string query = "INSERT INTO users(firstname, lastname, email, password, created_at, updated_at) VALUES (@firstname, @lastname, @email, @password, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public int GetLastId()
        {
            using (IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return Convert.ToInt32(dbConnection.ExecuteScalar("SELECT id FROM users ORDER by updated_at DESC;"));
            }
        }
        public int GetIdByEmail(string email)
        {
            using (IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return Convert.ToInt32(dbConnection.ExecuteScalar("SELECT id FROM users WHERE email = @email", new { email = email}));
            }
        }
        public User GetUserByEmail(string email)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE email = @email", new { email = email }).FirstOrDefault();
            }
        }
        public User GetUserById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE id = @id", new { id = id }).FirstOrDefault();
            }
        }
        public IEnumerable<User> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users");
            }
        }
    }
}

