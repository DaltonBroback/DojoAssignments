using System;
using System.Collections.Generic;
using DbConnection;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Read()
        {
            System.Console.WriteLine("Reading contents of user database...");
            List<Dictionary<string, object>> users = DbConnector.Query("SELECT * FROM users");
            System.Console.WriteLine("###################################################");
            System.Console.WriteLine();
            foreach(Dictionary<string, object> user in users){
                System.Console.WriteLine("User ID: "+user["id"]);
                System.Console.WriteLine("Name: "+user["FirstName"]+" "+user["LastName"]);
                System.Console.WriteLine("Favorite Number: "+user["FavoriteNumber"]);
                System.Console.WriteLine();
            }
            System.Console.WriteLine("###################################################");
        }

        public static void Create()
        {
            System.Console.WriteLine("To add a new user please input:");
            System.Console.WriteLine("First Name:");
            string firstname = Console.ReadLine();
            System.Console.WriteLine("Last Name:");
            string lastname = Console.ReadLine();
            System.Console.WriteLine("Favorite Number:");
            string favnum = Console.ReadLine();
            DbConnector.Execute("INSERT INTO `consoledb`.`users` (`FirstName`, `LastName`, `FavoriteNumber`) VALUES ('"+firstname+"', '"+lastname+"', '"+favnum+"');");
            System.Console.WriteLine("Adding new user...");
            Read();
        }

        public static void Update()
        {
            System.Console.WriteLine("Please enter ID of user to update");
            string idToEdit = Console.ReadLine();
            System.Console.WriteLine("First Name:");
            string firstname = Console.ReadLine();
            System.Console.WriteLine("Last Name:");
            string lastname = Console.ReadLine();
            System.Console.WriteLine("Favorite Number:");
            string favnum = Console.ReadLine();
            DbConnector.Execute("UPDATE `consoledb`.`users` SET `FirstName`='"+firstname+"', `LastName`='"+lastname+"', `FavoriteNumber`='"+favnum+"' WHERE `id`='"+idToEdit+"';");
            System.Console.WriteLine("Updating user....");
            Read();
        }
        
        public static void Delete()
        {
            System.Console.WriteLine("Please enter ID of user to delete");
            string idToDelete = Console.ReadLine();
            System.Console.WriteLine("Are you sure? This cannot be undone. (y/n)");
            string confirmchoice = Console.ReadLine();
            switch(confirmchoice){
                    case "y":
                        DbConnector.Execute("DELETE FROM `consoledb`.`users` WHERE `id`='"+idToDelete+"';");
                        Read();
                        System.Console.WriteLine("User deleted");
                        break;
                    default:
                    System.Console.WriteLine("Change abandoned");
                        break;
                }
                    
            }

        public static void Main(string[] args)
        {
            bool programloop = true;
            while(programloop == true){
                System.Console.WriteLine("###################################################");
                System.Console.WriteLine();
                System.Console.WriteLine();
                System.Console.WriteLine("Please Enter a Command");
                System.Console.WriteLine("READ to see information for all users");
                System.Console.WriteLine("CREATE to add a new user");
                System.Console.WriteLine("UPDATE to modify an existing user");
                System.Console.WriteLine("DELETE to delete an existing user");
                System.Console.WriteLine("QUIT to exit the application");
                System.Console.WriteLine();
                System.Console.WriteLine();
                System.Console.WriteLine("###################################################");
                string res = Console.ReadLine();
                switch(res){
                    case "READ":
                        Read();
                        break;
                    case "CREATE":
                        Create();
                        break;
                    case "UPDATE":
                        Update();
                        break;
                    case "DELETE":
                        Delete();
                        break;
                    case "QUIT":
                        programloop = false;
                        break;
                    default:
                        System.Console.WriteLine("Incorrect command. Please enter a valid command.");
                        break;
                }
            }
        }
    }
}
