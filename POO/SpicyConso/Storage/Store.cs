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
        
        public MySqlConnection connection;                                                      //variable pour la connection à une base de données MySQL

        /// <summary>
        /// Tente de se connecter à une base de données MySQL
        /// </summary>
        public void Connect ()
        {
            string server = "localhost";                                                        //adresse du serveur
            string userId = "root";                                                             //nom de l'utilisateur
            string pwd = "root";                                                                //mot de passe
            string database = "db_space_invaders";                                              //nom de la base de données
            string port = "6033";                                                               //numéro du port

            //proporiété pour la connection à une base de données mysql
            string connectString = $"server={server}; uid={userId}; pwd={pwd}; database={database}; port={port};";

            //ajout des propriétés au serveur MySQL
            connection = new MySqlConnection(connectString);

            //essaie de se connecter
            try {
                connection.Open();
                Debug.Write("Reussie");
            }
            //message d'erreur en cas de problème (dans la console debug)
            catch (MySqlException ex)
            { 
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Ferme la connexion à la base de données
        /// </summary>
        public void Close()
        {
            connection.Close();
        }

        /// <summary>
        /// Va chercher les pdseudos et les scores des 5 meilleurs joueurs à la base de données
        /// </summary>
        /// <param name="widthWorld"></param>
        /// <param name="height"></param>
        public void displayScore(int widthWorld, int height)
        {
            try
            {
                Connect();

                //requêtes SQL
                string command = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5";

                //représente une commande sur une base de donnée
                MySqlCommand cmd = new MySqlCommand(command, connection);

                //va lire la commande
                MySqlDataReader reader = cmd.ExecuteReader();

                //execute la commande
                for (int i = 1; reader.Read(); i++)
                {
                    Console.SetCursorPosition(widthWorld / 2 - 10, height + i);
                    Console.Write(i + ". " + reader["jouPseudo"]);
                    Console.SetCursorPosition(widthWorld / 2 + 15, height + i);
                    Console.Write(reader["jouNombrePoints"]);
                }
            }
            //message d'erreur en cas de problème
            catch
            {
                Console.SetCursorPosition(widthWorld / 2 - 7, height);
                Console.Write("Connexion impossible");
            }
        }

        /// <summary>
        /// Va insérer un score avec le pseudo dans la base de données
        /// </summary>
        /// <param name="player"></param>
        /// <param name="score"></param>
        public void insert(Player player, Score score, int widthWorld, int height)
        {
            try
            {
                Connect();

                //requête qui va insérer le score
                string command = $"INSERT INTO t_joueur(jouPseudo, jouNombrePoints) VALUES ('{player._name}', {score._score});";

                //représente une commande sur une base de donnée
                MySqlCommand cmd = new MySqlCommand(command, connection);

                //va lire la commande
                MySqlDataReader reader = cmd.ExecuteReader();

                //execute la commande
                reader.Read();
                Close();
            }
            //message d'erreur en cas de problème
            catch
            {
                Console.SetCursorPosition(widthWorld / 2 - 7, height + 3);
                Console.Write("Connexion impossible");
                Console.SetCursorPosition(widthWorld / 2 - 7, height + 6);
                Console.Write("Appuyer sur une touche");
                Console.ReadLine();
            }
        }
    }
}
