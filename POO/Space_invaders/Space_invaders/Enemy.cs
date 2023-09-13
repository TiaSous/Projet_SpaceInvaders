using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_invaders
{
    internal class Enemy
    {
        private int RightOrLeft = 1;
        public int _x;
        private int _y;
        public string[] _spriteEnemy =
            { 
             "{@v@}","/\" \"\\" 
        };
        public Enemy(int x)
        {
            _x = x;
        }
        public void Show()
        {
            for (int i = 0; i < _spriteEnemy.Length; i++)
            {
                Console.SetCursorPosition(_x, _y + i);
                Console.WriteLine(_spriteEnemy[i]);
            }
        }
        public void UpdateEnemy()
        {
            _x += 2 * RightOrLeft;
        }
        public void Down()
        {
            _y += _spriteEnemy.Length;
            RightOrLeft *= -1;
        }
    }
}
