using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
using System.Data.SqlClient;

namespace RepoLayer
{


    public interface IRepositoryClass
    {
       Task<Users> CreateUser(Users u);
    
    }
    public class Repository : IRepositoryClass
    {
        public async Task<Users> CreateUser (Users u){
            // user ADO.NET to push the data to the DB.
            SqlConnection conn = new SqlConnection("Server=tcp:lamb41.database.windows.net,1433;" + 
            "Initial Catalog=RevatureP1.db;Persist Security Info=False;" + 
            "User ID=benton;Password=Faithfirst41!;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;)");

            //configure the SQL query along with the connection object
            SqlCommand command = new SqlCommand($"INSERT INTO Users (Email, Password, Manager) VALUES (@Email,@Password,@Manager);", conn);

            //Open the Connection - you can access the SqlConnection object directly or through the SqlCommand obj!
            command.Connection.OpenAsync();

            // add the parameters to the query - do this to prevent Sql Injection
            command.Parameters.AddWithValue("@Email", u.Email);
            command.Parameters.AddWithValue("@Password", u.UserPassword);
            command.Parameters.AddWithValue("@Manager", u.Manager);
            int rowsAffected = await command.ExecuteNonQueryAsync();

            // verify that the query succeeded.
            if (rowsAffected == 1)
            {
                // query for that new customer to return to the client the customerId
                // call the private get a customer method to get a customer.
                conn.Close();
                return u;
            }
            else
            {
                return null;
            }
        }

      
    }
}