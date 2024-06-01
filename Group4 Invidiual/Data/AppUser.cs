using Group4_Invidiual.Data.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Invidiual.Data.Forms
{
    public class AppUser
    {
        public static void UserAdd(Users user)
        {
            OracleCommand command = new OracleCommand("CreateUser", POSContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("P_Username", user.Username);
            command.Parameters.Add("P_Password", user.Password);
            
            command.ExecuteNonQuery();
        }
        public static Users SelectUser (string username)
        {
            OracleCommand command = new OracleCommand("SelectUser", POSContext.GetConnection());
            command.CommandType= CommandType.StoredProcedure;

            command.Parameters.Add("P_Username", username);
            Users user = null;
            OracleDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                user = new Users();
                user.Username = reader["Username"].ToString();
            }
            return user;
        }
    }
}
