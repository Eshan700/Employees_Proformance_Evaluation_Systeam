using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_payroll.database
{
    class Db
    {
        public static MySqlConnection ConnectDB()
        {
            try
            {
               
                string connectionString;
                //98@Dil17
                connectionString = "Server=127.0.0.1;User=root;Database=performencedb;Port=3306;Password=98@Dil17;SSL Mode=None";
               
                MySqlConnection connection = new MySqlConnection(connectionString);
                return connection;
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }
    }
}
