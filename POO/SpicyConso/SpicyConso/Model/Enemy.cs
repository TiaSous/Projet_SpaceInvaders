
namespace Model
{
    public class Enemy
    {
        private int RightOrLeft = 1;
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
        public void Down()
        {
            this._y += 2;
            this.RightOrLeft *= -1;
        }
    }
}
