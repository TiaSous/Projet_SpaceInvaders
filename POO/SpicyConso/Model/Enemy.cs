
namespace Model
{
    public class Enemy
    {
        // attribut
        public int _x;                                                      // valeur x de l'ennemie
        public int _y;                                                      // valeur y de l'ennemie
        private const int NBRCASEDEPLACE = 1;                               // le nombre de case que l'ennemie se deplace
        private int RightOrLeft = 1;                                        // s'il va à gauche ou à droite 1 = droite, -1 = gauche 

        /// <summary>
        /// Constructeur pour décider ou commence l'ennemie sur la ligne horizontal 
        /// </summary>
        /// <param name="x"></param>
        public Enemy(int x)
        {
            _x = x;
        }
        
        /// <summary>
        /// va déplacer l'ennemie à gauche ou à droite d'un certain nombre de case
        /// </summary>
        public void UpdateEnemy()
        {
            _x += NBRCASEDEPLACE * RightOrLeft;
        }

        /// <summary>
        /// fais descendre l'ennemie de 2 case (hauteur de l'ennemi) et va changer la direction x de l'ennemie, c'est à dire s'il va à gaucher ou à droite
        /// </summary>
        public void Down()
        {
            this._y += 2;
            this.RightOrLeft *= -1;
        }
    }
}
