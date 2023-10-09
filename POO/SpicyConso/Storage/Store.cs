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
        
        public MySqlConnection connection;
        
        public void Connect ()
        {
            string server = "localhost";
            string uid = "root";
            string pwd = "root";
            string database = "db_space_invaders";
            string port = "6033";

            string connectString = $"server={server}; uid={uid}; pwd={pwd}; database={database}; port={port};";
            
            connection = new MySqlConnection(connectString);


            try {
                connection.Open();
                Debug.Write("Reussie");
            }

            catch (MySqlException ex)
            { 
                Debug.WriteLine(ex.Message);
            }
        }

        public void Close()
        {
            connection.Close();
        }

        public void displayScore()
        {
            Connect();
            string command = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5";
            MySqlCommand cmd = new MySqlCommand(command, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            for (int i = 1; reader.Read(); i++) 
            {
                Debug.WriteLine(i + ". " + reader["jouPseudo"] + "   " + reader["jouNombrePoints"]);
            }
        }

        public void insert(Player player, Score score)
        {
            Connect();
            string command = $"INSERT INTO t_joueur(jouPseudo, jouNombrePoints) VALUES ('{player._name}', {score._score});";
            MySqlCommand cmd = new MySqlCommand(command, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Close();
        }
    }
}
