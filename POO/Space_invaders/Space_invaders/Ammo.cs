using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_invaders
{
    internal class Ammo
    {
        public int _x;
        public int _y = 30;
        private string[] _spriteAmmo = {"|"};

        public Ammo(int x)
        {
            _x = x;
        }
        public void Show()
        {
            for (int i = 0; i < _spriteAmmo.Length; i++)
            {
                Console.SetCursorPosition(_x, _y + i);
                Console.WriteLine(_spriteAmmo[i]);
            }
        }
        public void AmmoUpdate()
        {
            if (_y <= 1)
            {
                _y = 0;
            }
            else
            {
                this._y -= 2;
            }
            
        }
    }
}
