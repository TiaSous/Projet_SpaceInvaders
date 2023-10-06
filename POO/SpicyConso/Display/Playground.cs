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

        private string[] _titleMainMenu = 
        {

            "███████╗██████╗  █████╗  ██████╗███████╗    ██╗███╗   ██╗██╗   ██╗ █████╗ ██████╗ ███████╗██████╗ ███████╗",
            "██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝    ██║████╗  ██║██║   ██║██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔════╝",
            "███████╗██████╔╝███████║██║     █████╗      ██║██╔██╗ ██║██║   ██║███████║██║  ██║█████╗  ██████╔╝███████╗",
            "╚════██║██╔═══╝ ██╔══██║██║     ██╔══╝      ██║██║╚██╗██║╚██╗ ██╔╝██╔══██║██║  ██║██╔══╝  ██╔══██╗╚════██║",
            "███████║██║     ██║  ██║╚██████╗███████╗    ██║██║ ╚████║ ╚████╔╝ ██║  ██║██████╔╝███████╗██║  ██║███████║",
            "╚══════╝╚═╝     ╚═╝  ╚═╝ ╚═════╝╚══════╝    ╚═╝╚═╝  ╚═══╝  ╚═══╝  ╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝"
        };
        private int _widthTitleMainMenu = 105;

        private string[] _titleOption = 
        {
           "  ██████╗ ██████╗ ████████╗██╗ ██████╗ ███╗   ██╗",
           " ██╔═══██╗██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║",
           " ██║   ██║██████╔╝   ██║   ██║██║   ██║██╔██╗ ██║",
           " ██║   ██║██╔═══╝    ██║   ██║██║   ██║██║╚██╗██║",
           " ╚██████╔╝██║        ██║   ██║╚██████╔╝██║ ╚████║",
           "  ╚═════╝ ╚═╝        ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝"
        };
        private int _widthTitleOption = 49;

        private string[] _titleRegles = {

           "██████╗ ███████╗ ██████╗ ██╗     ███████╗███████╗",
           "██╔══██╗██╔════╝██╔════╝ ██║     ██╔════╝██╔════╝",
           "██████╔╝█████╗  ██║  ███╗██║     █████╗  ███████╗",
           "██╔══██╗██╔══╝  ██║   ██║██║     ██╔══╝  ╚════██║",
           "██║  ██║███████╗╚██████╔╝███████╗███████╗███████║",
           "╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚══════╝╚══════╝╚══════╝"
        };
        private int _widthTitleRegles = 49;

        private string[] _titleClassement = { 
        
           "  ██████╗██╗      █████╗ ███████╗███████╗███████╗███╗   ███╗███████╗███╗   ██╗████████╗",
           " ██╔════╝██║     ██╔══██╗██╔════╝██╔════╝██╔════╝████╗ ████║██╔════╝████╗  ██║╚══██╔══╝",
           " ██║     ██║     ███████║███████╗███████╗█████╗  ██╔████╔██║█████╗  ██╔██╗ ██║   ██║   ",
           " ██║     ██║     ██╔══██║╚════██║╚════██║██╔══╝  ██║╚██╔╝██║██╔══╝  ██║╚██╗██║   ██║   ",
           " ╚██████╗███████╗██║  ██║███████║███████║███████╗██║ ╚═╝ ██║███████╗██║ ╚████║   ██║   ",
           "  ╚═════╝╚══════╝╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝   ╚═╝   "
        };
        private int _widthTitleClassement = 87;

        public string[] _mainMenu =
        {
            "Jouer",
            "Classement",
            "Option",
            "Règles",
            "Quitter"
        };
        private string _cursor = ">";

        private string _score = "Score: ";

        private string _ammo = "Munition: ";

        private int _startTitleHeight = 5;
        public int _startMenuHeight = 15;
        public void Init(Cursor cursor)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
            Console.SetBufferSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
            cursor._x = Config.SCREEN_WIDTH / 2 - 2;
            cursor._y = _startMenuHeight + 1;
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

        public void ShowTitleMainMenu()
        {
            for (int i = 0; i < _titleMainMenu.Length; i++)
            { 
                Console.SetCursorPosition(Config.SCREEN_WIDTH/2 - _widthTitleMainMenu/2, _startTitleHeight + i);
                Console.WriteLine(_titleMainMenu[i]);
            }
            for (int i = 0; i < _mainMenu.Length; i++)
            {
                Console.SetCursorPosition(Config.SCREEN_WIDTH / 2, _startMenuHeight + 1 + i);
                Console.WriteLine(_mainMenu[i]);
            }
        }

        public void ShowOption()
        {
            for (int i = 0; i < _titleMainMenu.Length; i++)
            {
                Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - _widthTitleOption / 2, _startTitleHeight + i);
                Console.WriteLine(_titleOption[i]);
            }
        }
        public void ShowRegles()
        {
            for (int i = 0; i < _titleRegles.Length; i++)
            {
                Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - _widthTitleRegles / 2, _startTitleHeight + i);
                Console.WriteLine(_titleRegles[i]);
            }
        }
        public void ShowClassement()
        {
            for (int i = 0; i < _titleClassement.Length; i++)
            {
                Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - _widthTitleClassement / 2, _startTitleHeight + i);
                Console.WriteLine(_titleClassement[i]);
            }
        }

        public void Show(Cursor cursor)
        {
            Console.SetCursorPosition(cursor._x, cursor._y);
            Console.Write(_cursor);
        }
        
        public void ShowScore(Score score)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(_score + score._score);
        }
        public void ShowAmmo (Player player)
        {
            Console.SetCursorPosition(0, 1);
            Console.Write(_ammo + player.chargerAmmo.Count);
        }
    }
}
