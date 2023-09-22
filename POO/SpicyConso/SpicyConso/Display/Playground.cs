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
        private string[] _spriteEnemy =
    {
             "{@v@}","/\" \"\\"
        };
        private string[] _spriteAmmo = { "|" };
        public void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
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
