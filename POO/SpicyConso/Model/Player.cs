using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {
        public int _speed = 2;
        public int _x = 75;
        public int _y = ConfigWorld.POSITION_Y_PLAYER_FOR_START;
        const int LIMIT_AMMO = 150;
        public List <Ammo> chargerAmmo = new List <Ammo>();
        public int _enemiesKillToGiveAmmo = 0;

        public void InitPlayer()
        {
            for (int i = 0; i < LIMIT_AMMO; i++)
            {
                chargerAmmo.Add(new Ammo());
            }
        }

        public void AddAmmo(int numberAmmo)
        {
            for (int i = 0; i < numberAmmo; i++)
            {
                chargerAmmo.Add(new Ammo());
            }
        }

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
        


    }
}
