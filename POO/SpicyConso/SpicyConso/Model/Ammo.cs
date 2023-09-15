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
        public int _y = 30;


        public Ammo(int x)
        {
            _x = x;
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
