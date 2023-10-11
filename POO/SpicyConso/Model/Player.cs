using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {

        // attribut
        public int _x = 75;                                                 // la position horizontenale du joueur
        public int _y = ConfigWorld.POSITION_Y_PLAYER_FOR_START;            // la position verticale du joueur
        const int LIMIT_AMMO = 150;                                         // nombre maximale de balle
        public int _enemiesKillToGiveAmmo = 0;                              // nombre d'ennemie tué pour recevoir des balles
        public string _name = "";                                           // nm du joueur
        private const int _speed = 2;                                       // le nombre de case où il se deplace
        public int Speed
        {
            get { return _speed; }
        }

        // liste
        // nombre de munition dans le chargeur
        public List<Ammo> chargerAmmo = new List<Ammo>();

        /// <summary>
        /// constructeur qui va mettre le nombre maximal de munitions dans le chargeur du joueur
        /// </summary>
        public Player()
        {
            for (int i = 0; i < LIMIT_AMMO; i++)
            {
                chargerAmmo.Add(new Ammo());
            }
        }

        /// <summary>
        /// va ajouter des balles dans le chargeur
        /// </summary>
        /// <param name="numberAmmo"></param>
        public void AddAmmo(int numberAmmo)
        {
            if (chargerAmmo.Count + numberAmmo <= chargerAmmo.Count)
            {
                for (int i = 0; i < numberAmmo; i++)
                {
                    chargerAmmo.Add(new Ammo());
                }
            }
            else
            {
                while(chargerAmmo.Count == LIMIT_AMMO)
                {
                    chargerAmmo.Add(new Ammo());
                }
            }
        }

        /// <summary>
        /// va mettre à joueur la position du joueur
        /// </summary>
        /// <param name="move"></param>
        public void PlayerMovementUpdate(int move)
        {
            if (_x + move < ConfigWorld.WORLD_WIDTH_LEFT|| _x + move > ConfigWorld.WORLD_WIDTH_RIGHT)
            {
                move = 0;
            }
            else
            {
                _x += move;
            }
        }
        
        /// <summary>
        /// le joueur met un pseudo
        /// </summary>
        /// <param name="pseudo"></param>
        public void EnterName(string pseudo)
        {
            _name = pseudo;
        }

    }
}
