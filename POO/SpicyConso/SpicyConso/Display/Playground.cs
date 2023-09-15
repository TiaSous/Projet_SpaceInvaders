using Model;

namespace Display
{
    public class Playground
    {
        private string[] _spriteShip =
      {
         @" /|\ ",
         @"/|||\",
         @"|||||",
         @" | | ",
     };
        public string[] _spriteEnemy =
    {
             "{@v@}","/\" \"\\"
        };
        private string[] _spriteAmmo = { "|" };
        public static void Init()
        {
            Console.CursorVisible = false;
        }
        public void Show(Player player)
        {
            for (int i = 0; i < _spriteShip.Length; i++)
            {
                Console.SetCursorPosition(player._x, player._y + i);
                Console.WriteLine(_spriteShip[i]);
            }
        }
        public void Show(Enemy enemy)
        {
            for (int i = 0; i < _spriteEnemy.Length; i++)
            {
                Console.SetCursorPosition(enemy._x, enemy._y + i);
                Console.WriteLine(_spriteEnemy[i]);
            }
        }
        public void Down(Enemy enemy)
        {
            enemy._y += _spriteEnemy.Length;
            enemy.RightOrLeft *= -1;
        }
        public void Show(Ammo ammo)
        {
            for (int i = 0; i < _spriteAmmo.Length; i++)
            {
                Console.SetCursorPosition(ammo._x, ammo._y + i);
                Console.WriteLine(_spriteAmmo[i]);
            }
        }
    }
}
