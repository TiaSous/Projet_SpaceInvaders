using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cursor
    {
        // attribut
        public int _x;          // postion x du curseur
        public int _y = 0;      // position y du curseur

        /// <summary>
        /// met à jour la position verticale lorsqu'il descend
        /// </summary>
        public void MoveDown()
        {
            _y += 1;
        }
        /// <summary>
        /// met à jour la position verticale lorsqu'il monte
        /// </summary>
        public void MoveUp()
        {
            _y -= 1;
        }
    }
}
