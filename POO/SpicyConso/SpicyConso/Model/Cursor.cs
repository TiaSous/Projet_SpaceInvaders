using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cursor
    {
        public int _x;
        public int _y = 0;

        public void MoveDown()
        {
            _y += 1;
        }
        public void MoveUp()
        {
            _y -= 1;
        }
    }
}
