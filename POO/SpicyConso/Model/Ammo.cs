using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ammo
    {
        public int _x;
        public int _y = ConfigWorld.POSITION_Y_PLAYER_FOR_START;


        public Ammo(int x)
        {
            _x = x;
        }
        public Ammo()
        {
            _x = 0;
        }
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
