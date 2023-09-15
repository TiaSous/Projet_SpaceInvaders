using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Enemy
    {
        public int RightOrLeft = 1;
        public int _x;
        public int _y;

        public Enemy(int x)
        {
            _x = x;
        }
        
        public void UpdateEnemy()
        {
            _x += 2 * RightOrLeft;
        }
        
    }
}
