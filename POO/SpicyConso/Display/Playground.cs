using Model;
using Storage;
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
     };                     //sprite du joueur
        private string[] _spriteEnemy =
    {
             "{@v@}","/\" \"\\"
        };                    //sprite de l'ennemie
        private string[] _spriteAmmo = { "|" };                //sprite de la balle

        private string[] _titleMainMenu = 
        {

            "███████╗██████╗  █████╗  ██████╗███████╗    ██╗███╗   ██╗██╗   ██╗ █████╗ ██████╗ ███████╗██████╗ ███████╗",
            "██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝    ██║████╗  ██║██║   ██║██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔════╝",
            "███████╗██████╔╝███████║██║     █████╗      ██║██╔██╗ ██║██║   ██║███████║██║  ██║█████╗  ██████╔╝███████╗",
            "╚════██║██╔═══╝ ██╔══██║██║     ██╔══╝      ██║██║╚██╗██║╚██╗ ██╔╝██╔══██║██║  ██║██╔══╝  ██╔══██╗╚════██║",
            "███████║██║     ██║  ██║╚██████╗███████╗    ██║██║ ╚████║ ╚████╔╝ ██║  ██║██████╔╝███████╗██║  ██║███████║",
            "╚══════╝╚═╝     ╚═╝  ╚═╝ ╚═════╝╚══════╝    ╚═╝╚═╝  ╚═══╝  ╚═══╝  ╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝"
        };                  //sprite du titre du menu principal
        private int _widthTitleMainMenu = 105;                 //largeur du titre du menu principale

        private string[] _titleOption = 
        {
           " ██████╗ ██████╗ ████████╗██╗ ██████╗ ███╗   ██╗███████╗",
           "██╔═══██╗██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║██╔════╝",
           "██║   ██║██████╔╝   ██║   ██║██║   ██║██╔██╗ ██║███████╗",
           "██║   ██║██╔═══╝    ██║   ██║██║   ██║██║╚██╗██║╚════██║",
           "╚██████╔╝██║        ██║   ██║╚██████╔╝██║ ╚████║███████║",
           " ╚═════╝ ╚═╝        ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝"
        };                    //sprite du titre du menu des options   
        private int _widthTitleOption = 56;                    //largeur du titre du menu des options  

        private string[] _titleRegles = {

           "██████╗ ███████╗ ██████╗ ██╗     ███████╗███████╗",
           "██╔══██╗██╔════╝██╔════╝ ██║     ██╔════╝██╔════╝",
           "██████╔╝█████╗  ██║  ███╗██║     █████╗  ███████╗",
           "██╔══██╗██╔══╝  ██║   ██║██║     ██╔══╝  ╚════██║",
           "██║  ██║███████╗╚██████╔╝███████╗███████╗███████║",
           "╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚══════╝╚══════╝╚══════╝"
        };                    //sprite du titre du menu des règles
        private int _widthTitleRegles = 49;                    //largeur du titre du menu des règles  

        private string[] _titleClassement = { 
        
           "  ██████╗██╗      █████╗ ███████╗███████╗███████╗███╗   ███╗███████╗███╗   ██╗████████╗",
           " ██╔════╝██║     ██╔══██╗██╔════╝██╔════╝██╔════╝████╗ ████║██╔════╝████╗  ██║╚══██╔══╝",
           " ██║     ██║     ███████║███████╗███████╗█████╗  ██╔████╔██║█████╗  ██╔██╗ ██║   ██║   ",
           " ██║     ██║     ██╔══██║╚════██║╚════██║██╔══╝  ██║╚██╔╝██║██╔══╝  ██║╚██╗██║   ██║   ",
           " ╚██████╗███████╗██║  ██║███████║███████║███████╗██║ ╚═╝ ██║███████╗██║ ╚████║   ██║   ",
           "  ╚═════╝╚══════╝╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝   ╚═╝   "
        };                //sprite du titre du menu du classement
        private int _widthTitleClassement = 87;                //largeur du titre du menu du classement 

        public string[] _mainMenu =
        {
            "Jouer",
            "Classement",
            "Options",
            "Règles",
            "Quitter"
        };                        //options dans le jeu

        private string _cursor = ">";                          //sprite du curseur

        private string[] _gameOver =
            {

           " ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ ",
           "██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗",
           "██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝",
           "██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗",
           "╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║",
           " ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝"
        };                       //sprite du game over
        private int _widthGameOver = 74;                       //largeur du titre game over

        private string _score = "Score: ";

        private string _ammo = "Munition: ";

        private int _startTitleHeight = 5;                     //hauteur du quel le titre commence
        public int _startMenuHeight = 15;                      //hauteur du quel les options dans le menu principale commence

        /// <summary>
        /// Configuration de départ
        /// </summary>
        /// <param name="cursor"></param>
        public void Init(Cursor cursor)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
            Console.SetBufferSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
            cursor._x = Config.SCREEN_WIDTH / 2 - 2;
            cursor._y = _startMenuHeight + 1;
        }

        /// <summary>
        /// rend le curseur visible
        /// </summary>
        public void VisibleCursor()
        {
            Console.CursorVisible = true;
        }

        /// <summary>
        /// rend le curseur invisible
        /// </summary>
        public void NotVisibleCursor()
        {
            Console.CursorVisible = false;
        }

        /// <summary>
        /// affiche le joueur
        /// </summary>
        /// <param name="player"></param>
        public void ShowPlayer(Player player)
        {
            for (int i = 0; i < _spriteShip.Length; i++)
            {
                Console.SetCursorPosition(player._x, player._y + i);
                Console.WriteLine(_spriteShip[i]);
            }
        }

        /// <summary>
        /// affiche l'ennemie
        /// </summary>
        /// <param name="enemy"></param>
        public void ShowEnemie(Enemy enemy)
        {
            for (int i = 0; i < _spriteEnemy.Length; i++)
            {
                Console.SetCursorPosition(enemy._x, enemy._y + i);
                Console.WriteLine(_spriteEnemy[i]);
            }
        }

        /// <summary>
        /// affiche la balle
        /// </summary>
        /// <param name="ammo"></param>
        public void ShowAmmo(Ammo ammo)
        {
            for (int i = 0; i < _spriteAmmo.Length; i++)
            {
                Console.SetCursorPosition(ammo._x, ammo._y + i);
                Console.WriteLine(_spriteAmmo[i]);
            }
        }

        /// <summary>
        /// affiche le menu principale
        /// </summary>
        public void ShowTitleMainMenu()
        {
            //titre
            for (int i = 0; i < _titleMainMenu.Length; i++)
            { 
                Console.SetCursorPosition(Config.SCREEN_WIDTH/2 - _widthTitleMainMenu/2, _startTitleHeight + i);
                Console.WriteLine(_titleMainMenu[i]);
            }
            //option
            for (int i = 0; i < _mainMenu.Length; i++)
            {
                Console.SetCursorPosition(Config.SCREEN_WIDTH / 2, _startMenuHeight + 1 + i);
                Console.WriteLine(_mainMenu[i]);
            }
        }

        /// <summary>
        /// affiche les options
        /// </summary>
        public void ShowOption()
        {
            for (int i = 0; i < _titleMainMenu.Length; i++)
            {
                Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - _widthTitleOption / 2, _startTitleHeight + i);
                Console.WriteLine(_titleOption[i]);
            }
        }

        /// <summary>
        /// affiche les règles
        /// </summary>
        public void ShowRegles()
        {
            for (int i = 0; i < _titleRegles.Length; i++)
            {
                Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - _widthTitleRegles / 2, _startTitleHeight + i);
                Console.WriteLine(_titleRegles[i]);
            }
        }

        /// <summary>
        /// affiche le classement
        /// </summary>
        /// <param name="store"></param>
        public void ShowClassement(Store store)
        {
            for (int i = 0; i < _titleClassement.Length; i++)
            {
                Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - _widthTitleClassement / 2, _startTitleHeight + i);
                Console.WriteLine(_titleClassement[i]);
            }
            store.displayScore(Config.SCREEN_WIDTH, _startMenuHeight);

            Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - 7, _startMenuHeight + 10);
            Console.Write("Appuyer sur une touche");
        }

        /// <summary>
        /// affiche le curseur du menu principal
        /// </summary>
        /// <param name="cursor"></param>
        public void Show(Cursor cursor)
        {
            Console.SetCursorPosition(cursor._x, cursor._y);
            Console.Write(_cursor);
        }
        
        /// <summary>
        /// affiche le score
        /// </summary>
        /// <param name="score"></param>
        public void ShowScore(Score score)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(_score + score._score);
        }

        /// <summary>
        /// affiche le nombre de munitions restantes
        /// </summary>
        /// <param name="player"></param>
        public void ShowAmmo (Player player)
        {
            Console.SetCursorPosition(0, 1);
            Console.Write(_ammo + player.chargerAmmo.Count);
        }

        /// <summary>
        /// affiche l'écran de fin
        /// </summary>
        /// <param name="score"></param>
        public void ShowGameOver(Score score)
        {
            int y = 0;
            for (int i = 0; i < _titleMainMenu.Length; i++)
            {
                Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - _widthGameOver / 2, _startTitleHeight + i);
                Console.WriteLine(_gameOver[i]);
                y = Console.CursorTop;
            }
            Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - 4, y + 2);
            Console.Write(_score + score._score);
            Console.SetCursorPosition(Config.SCREEN_WIDTH / 2 - 6, y + 4);
            Console.Write("Entre un nom: ");
        }
    }
}
