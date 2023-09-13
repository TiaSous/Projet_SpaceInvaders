using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_invaders
{
    internal class Player
    {
        public int _vitesse = 2;
        public int _x = 75;
        private int _y = 30;
        private string[] _spriteShip =
      {
         @" /|\ ",
         @"/|||\",
         @"|||||",
         @" | | ",
     };
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
        public void Show()
        {
            for (int i = 0; i < _spriteShip.Length; i++)
            {
                Console.SetCursorPosition(_x, _y + i);
                Console.WriteLine(_spriteShip[i]);
            }
        }

    }
}
