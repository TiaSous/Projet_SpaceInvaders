using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_invaders
{
    internal class Player
    {
        public int _x;
        private int _y = 3;
        private string[] _spriteShip =
      {
         @" /|\ ",
         @"/|||\",
         @"|||||",
         @" | | ",
     };
        public void Update(int move)
        {
            _x += move;
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
