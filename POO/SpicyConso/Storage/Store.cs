using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Model;

namespace Storage
{
    public class Store
    {
        
        
        public static void Connect ()
        {
            string server = "localhost";
            string uid = "root";
            string pwd = "root";
            string database = "db_space_invaders";
            string port = "6033";

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = $"server={server}; uid={uid}; pwd={pwd}; database={database}; port={port}";

            try {
                conn.Open();
                Debug.Write("Reussie");
            }

            catch (MySqlException ex)
            { 
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
