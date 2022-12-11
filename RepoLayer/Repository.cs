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
       Task<Users> GetUser(Users u);
       Task<Tickets> CreateTicket(Tickets t);
       Task<Tickets> UpdateTicket(Tickets t);
       Task<List<Tickets>> GetPendingTickets();
       Task<List<Tickets>> GetMyTickets(Tickets t);
       Task<Users> UpdateUser(Users u);
    }
    public class Repository : IRepositoryClass
    {
        public async Task<Users> CreateUser (Users u){
            // user ADO.NET to push the data to the DB.
            SqlConnection conn = new SqlConnection("Server=tcp:lamb41.database.windows.net,1433;Initial Catalog=RevatureP1.db;Persist Security Info=False;User ID=benton;Password=Faithfirst41!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //configure the SQL query along with the connection object
            SqlCommand command = new SqlCommand($"INSERT INTO Users (Email, UserPassword, Manager) VALUES (@Email,@UserPassword,'false');", conn);

            //Open the Connection - you can access the SqlConnection object directly or through the SqlCommand obj!
            await conn.OpenAsync();

            // add the parameters to the query - do this to prevent Sql Injection
            command.Parameters.AddWithValue("@Email", u.Email);
            command.Parameters.AddWithValue("@UserPassword", u.UserPassword);
            int rowsAffected = await command.ExecuteNonQueryAsync();

            // verify that the query succeeded.
            if (rowsAffected == 1)
            {
                // query for that new customer to return to the client the customerId
                // call the private get a customer method to get a customer.
                await conn.CloseAsync();
                return u;
            }
            else
            {
                await conn.CloseAsync();
                return null;
            }
        }

        public async Task<Users> GetUser(Users u) {
            // user ADO.NET to push the data to the DB.
            SqlConnection conn = new SqlConnection("Server=tcp:lamb41.database.windows.net,1433;Initial Catalog=RevatureP1.db;Persist Security Info=False;User ID=benton;Password=Faithfirst41!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //configure the SQL query along with the connection object
            SqlCommand command = new SqlCommand($"SELECT * FROM Users Where Email = '@Email' AND UserPassword = '@UserPassword';", conn);
    

            //Open the Connection - you can access the SqlConnection object directly or through the SqlCommand obj!
            // command.Connection.Open();
            await conn.OpenAsync();

            // add the parameters to the query - do this to prevent Sql Injection
            command.Parameters.AddWithValue("@Email", u.Email);
            command.Parameters.AddWithValue("@UserPassword", u.UserPassword);
            int rowsAffected = await command.ExecuteNonQueryAsync();


            // await conn.CloseAsync();
            return u;
        }

        public async Task<Tickets> CreateTicket (Tickets t){
            // user ADO.NET to push the data to the DB.
            SqlConnection conn = new SqlConnection("Server=tcp:lamb41.database.windows.net,1433;Initial Catalog=RevatureP1.db;Persist Security Info=False;User ID=benton;Password=Faithfirst41!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //configure the SQL query along with the connection object
            SqlCommand command = new SqlCommand($"INSERT INTO Tickets (TickType, TickAmount, TickDescription, TickStatus, UserID) VALUES (@TickType, @TickAmount, @TickDescription, 'Pending', @UserID);", conn);

            //Open the Connection - you can access the SqlConnection object directly or through the SqlCommand obj!
            // command.Connection.OpenAsync();
            await conn.OpenAsync();


            // add the parameters to the query - do this to prevent Sql Injection
            command.Parameters.AddWithValue("@TickType", t.TickType);
            command.Parameters.AddWithValue("@TickAmount", t.TickAmount);
            command.Parameters.AddWithValue("@TickDescription", t.TickDescription);
            command.Parameters.AddWithValue("@UserID", t.UserID);
            int rowsAffected = await command.ExecuteNonQueryAsync();

            // verify that the query succeeded.
            if (rowsAffected == 1)
            {
                // query for that new customer to return to the client the customerId
                // call the private get a customer method to get a customer.
                await conn.CloseAsync();
                return t;
            }
            else
            {
                await conn.CloseAsync();
                return null;
            }
        }

            public async Task<Tickets> UpdateTicket (Tickets t){
            SqlConnection conn = new SqlConnection("Server=tcp:lamb41.database.windows.net,1433;Initial Catalog=RevatureP1.db;Persist Security Info=False;User ID=benton;Password=Faithfirst41!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            SqlCommand command = new SqlCommand($"UPDATE Tickets SET TickStatus = @TickStatus WHERE TickID = @TickID;", conn);

            command.Connection.Open();

            command.Parameters.AddWithValue("@TickID", t.TickID);
            command.Parameters.AddWithValue("@TickStatus", t.TickStatus);
            int rowsAffected = await command.ExecuteNonQueryAsync();

            if (rowsAffected == 1)
            {
                conn.Close();
                return t;
            }
            else
            {
                return null;
            }
        }


            public async Task<List<Tickets>> GetPendingTickets(){
            SqlConnection conn = new SqlConnection("Server=tcp:lamb41.database.windows.net,1433;Initial Catalog=RevatureP1.db;Persist Security Info=False;User ID=benton;Password=Faithfirst41!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            SqlCommand command = new SqlCommand($"SELECT * FROM Tickets WHERE TickStatus = 'Pending'", conn);

            command.Connection.Open();
            Task<SqlDataReader> ret = command.ExecuteReaderAsync();

            List<Tickets> list = new List<Tickets>();

            SqlDataReader ret1 = await ret;
            while (await ret1.ReadAsync())
            {
                list.Add(new Tickets(ret1.GetInt32(0), ret1.GetString(1), ret1.GetDouble(2), ret1.GetString(3), ret1.GetString(4), ret1.GetInt32(5)));
            }
            return list;
            }

            public async Task<List<Tickets>> GetMyTickets(Tickets t){
            SqlConnection conn = new SqlConnection("Server=tcp:lamb41.database.windows.net,1433;Initial Catalog=RevatureP1.db;Persist Security Info=False;User ID=benton;Password=Faithfirst41!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            SqlCommand command = new SqlCommand($"SELECT * FROM Tickets WHERE UserID = @UserID", conn);

            command.Connection.Open();
            command.Parameters.AddWithValue("@UserID", t.UserID);
            Task<SqlDataReader> ret = command.ExecuteReaderAsync();

            List<Tickets> list = new List<Tickets>();

            SqlDataReader ret1 = await ret;
            while (await ret1.ReadAsync())
            {
                list.Add(new Tickets(ret1.GetInt32(0), ret1.GetString(1), ret1.GetDouble(2), ret1.GetString(3), ret1.GetString(4), ret1.GetInt32(5)));
            }
            return list;
            }


            public async Task<Users> UpdateUser (Users u){
            SqlConnection conn = new SqlConnection("Server=tcp:lamb41.database.windows.net,1433;Initial Catalog=RevatureP1.db;Persist Security Info=False;User ID=benton;Password=Faithfirst41!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            SqlCommand command = new SqlCommand($"UPDATE Users SET Email = @Email, UserPassword = @UserPassword, Manager = @Manager WHERE UserID = @UserID;", conn);

            command.Connection.Open();

            command.Parameters.AddWithValue("@UserID", u.UserId);
            command.Parameters.AddWithValue("@Email", u.Email);
            command.Parameters.AddWithValue("@UserPassword", u.UserPassword);
            command.Parameters.AddWithValue("@Manager", u.Manager);
            int rowsAffected = await command.ExecuteNonQueryAsync();

            if (rowsAffected == 1)
            {
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