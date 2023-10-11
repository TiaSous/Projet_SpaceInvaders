using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Score
    {
        // attribut
        public int _score;          // le score de la partie

        /// <summary>
        /// rajoute 10 de score à chaque ennemi tué
        /// </summary>
        public void AddScore()
        {
            _score += 10;
        }
    }
}
