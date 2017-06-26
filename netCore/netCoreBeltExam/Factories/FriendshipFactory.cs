using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using netCoreBeltExam.Models;
using System;

namespace netCoreBeltExam.Factory
{
    public class FriendshipFactory : IFactory<Friendship>
    {
        private string connectionString;
        public FriendshipFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=beltexam;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public IEnumerable<Friendship> GetPendingRequestIds(User item)
        {
            using (IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return dbConnection.Query<Friendship>("SELECT * FROM friendships WHERE user1 = @id AND status = 0 AND action_user_id != @id OR user2 = @id AND status = 0 AND action_user_id != @id;");
            }
        }
        public IEnumerable<int> GetFriendRequestsIds(int userid)
        {
            using (IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return dbConnection.Query<int>("SELECT user1 FROM friendships WHERE user1 = "+userid+" AND status = 0 AND action_user_id != "+userid+" OR user2 = "+userid+" AND status = 0 AND action_user_id != "+userid+";");
            }
        }
        public IEnumerable<int> GetFriendIds1(int userid)
        {
            using (IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return dbConnection.Query<int>("SELECT user1 FROM friendships WHERE status = 1 AND user2 = "+userid);
            }
        }
        public IEnumerable<int> GetFriendIds2(int userid)
        {
            using (IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return dbConnection.Query<int>("SELECT user2 FROM friendships WHERE status = 1 AND user1 = "+userid);
            }
        }
        public IEnumerable<int> FindNoRelationship(int userid)
        {
            using (IDbConnection dbConnection = Connection)
                {
                    var query =
                    "SELECT id FROM users WHERE id != "+userid+" AND id NOT IN (SELECT user1 FROM friendships WHERE user2 = "+userid+") AND id NOT IN (SELECT user2 FROM friendships WHERE user1 = "+userid+")";
                    dbConnection.Open();
                    return dbConnection.Query<int>(query);
            }
        }

        public void SendRequest(int senderid, int targetid){
            using (IDbConnection dbConnection = Connection){
                string query ="INSERT INTO friendships (user1, user2, status, action_user_id) VALUES ("+senderid+", "+targetid+", 0, "+senderid+")";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
        public void AcceptRequest(int userid, int requesterid){
            using (IDbConnection dbConnection = Connection){
                string query ="UPDATE friendships SET status = 1, action_user_id="+userid+" WHERE user1 = "+requesterid+" AND user2 ="+userid+";";
                System.Console.WriteLine(query);
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
        public void IgnoreRequest(int userid, int requesterid){
            using (IDbConnection dbConnection = Connection){
                string query ="DELETE FROM friendships WHERE user1 = "+requesterid+" AND user2 = "+userid+";";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
    }
}

