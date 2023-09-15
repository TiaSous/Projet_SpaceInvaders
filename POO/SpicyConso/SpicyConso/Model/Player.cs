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
        public int _y = 30;
        
        public void PlayerMovementUpdate(int move)
        {
            if (_x + move < 20 + 5|| _x + move + 5> 135)
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
