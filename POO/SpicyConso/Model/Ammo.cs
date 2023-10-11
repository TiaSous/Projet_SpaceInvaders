using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ammo
    {
        // attribut
        public int _x;                                                              // valeur horizontal de la bale
        public int _y = ConfigWorld.POSITION_Y_PLAYER_FOR_START;                    // valeur vertical de la balle

        /// <summary>
        /// Constructeur lorsque le joueur tire la balle prend la même position que le joueur
        /// </summary>
        /// <param name="x"></param>
        public Ammo(int x)
        {
            _x = x;
        }

        /// <summary>
        /// Constructeur pour mettre des balles dans le chargeur du joueur
        /// </summary>
        public Ammo()
        {
            _x = 0;
        }

        /// <summary>
        /// met à jour les balles
        /// </summary>
        public void AmmoUpdate()
        {
            if (_y <= 1)
            {
                _y = 0;
            }
            else
            {
                this._y -= 1;
            }
            
        }
    }
}
