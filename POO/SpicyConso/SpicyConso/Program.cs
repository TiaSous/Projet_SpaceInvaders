using Model;
using Display;
using Storage;
using System.Numerics;

// instanciation des objet
Playground playground = new Playground();
Cursor cursor = new Cursor();
Store store = new Store();

// initialisation de la configuration de base
playground.Init(cursor);

//récupère l'input du clavier
ConsoleKeyInfo keyPressed;

// déclaration de variables
int optionChoose = 0;

// début du programme
do
{
    Console.Clear();

    // lance le menu principale
    do
    {
        // met les variables à leur valeur par défaut
        optionChoose = 0;

        // affichage
        playground.ShowTitleMainMenu();
        playground.Show(cursor);

        // si input
        if (Console.KeyAvailable)
        {
            // lit le caractère en ne l'affichant pas
            keyPressed = Console.ReadKey(true);
            switch (keyPressed.Key)
            {
                case ConsoleKey.UpArrow:
                    if (cursor._y == playground._startMenuHeight + 1)
                    { }
                    else
                    {
                        cursor.MoveUp();
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (cursor._y == playground._mainMenu.Length + playground._startMenuHeight)
                    { }
                    else
                    {
                        cursor.MoveDown();
                    }
                    break;
                case ConsoleKey.Enter:
                    optionChoose = cursor._y - playground._startMenuHeight;
                    break;
                default:
                    break;
            }
            Console.Clear();
        }
    }
    while (optionChoose == 0);

    // jeux
    if (optionChoose == 1)
    {

        // déclaration de liste
        List<Ammo> ammoShotList = new List<Ammo>();
        List<Enemy> nbrEnemyList = new List<Enemy>();

        // instanciation d'objet
        Score score = new Score();
        Player player = new Player();
        Random numberEnemies = new Random();

        // déclaration de variables
        bool gameFinish = false;
        int frameNumber = 0;

        // ajoute 10 ennemis dans le jeux
        for (int i = 0; i < 10; i++)
        {
            nbrEnemyList.Add(new Enemy(i * 5 + 50));
        }
 
        ////////////////////////////////// début du jeu//////////////////////////////////////
        do
        {
            // si input
            if (Console.KeyAvailable)
            {
                // lit le caractère en ne l'affichant pas
                keyPressed = Console.ReadKey(true);

                // quel input fais quoi
                switch (keyPressed.Key)
                {
                    case ConsoleKey.A:
                        player.PlayerMovementUpdate(-1 * player.Speed);
                        break;
                    case ConsoleKey.D:
                        player.PlayerMovementUpdate(1 * player.Speed);
                        break;
                    case ConsoleKey.Spacebar:
                        if (player.chargerAmmo.Count > 0)
                        {
                            ammoShotList.Add(new Ammo(player._x + 2));
                            player.chargerAmmo.RemoveAt(0);
                        }
                        break;
                    default:
                        break;
                }
            }
            ////////////////////////////////////////MET A JOUR///////////////////////////////
            // met à jour les balles
            if (ammoShotList.Count > 0)
            {
                // va mettre chaque balle
                for (int i = ammoShotList.Count - 1; i >= 0; i--)
                {
                    ammoShotList[i].AmmoUpdate();
                    if (ammoShotList[i]._y == 0)
                    {
                        ammoShotList.Remove(ammoShotList[i]);
                    }
                }

                //vérifie s'il y a une colision entre une balle et un ennemie
                for (int i = nbrEnemyList.Count - 1; i >= 0; i--)
                {
                    for (int a = ammoShotList.Count - 1; a >= 0; a--)
                    {
                        if (ammoShotList[a]._x >= nbrEnemyList[i]._x && ammoShotList[a]._x <= nbrEnemyList[i]._x + 4)
                        {
                            if (ammoShotList[a]._y >= nbrEnemyList[i]._y && ammoShotList[a]._y <= nbrEnemyList[i]._y + 1)
                            {
                                ammoShotList.Remove(ammoShotList[a]);
                                nbrEnemyList.Remove(nbrEnemyList[i]);
                                player._enemiesKillToGiveAmmo++;
                                score.AddScore();
                                break;
                            }
                        }
                    }
                }
            }

            //rajoute 3 balles chaque 5 ennemies tué
            if (player._enemiesKillToGiveAmmo == 5)
            {
                player.AddAmmo(3);
                player._enemiesKillToGiveAmmo = 0;
            }

            // les ennemies vont en bas si un ennemie touche la borudure
            if (frameNumber % 3 == 0)
            {
                foreach (Enemy nbrEnemy in nbrEnemyList)
                {
                    if (nbrEnemy._x > ConfigWorld.WORLD_WIDTH_RIGHT || nbrEnemy._x < ConfigWorld.WORLD_WIDTH_LEFT)
                    {
                        foreach (Enemy nbrEnemy2 in nbrEnemyList)
                        {
                            nbrEnemy2.Down();
                        }
                    }
                }
            }

            // met à jour les ennemies
            if (frameNumber % 3 == 0)
            {
                foreach (Enemy nbrEnemy in nbrEnemyList)
                {
                    nbrEnemy.UpdateEnemy();
                }
            }
            Console.Clear();

            ////////////////////////////////////////AFFICHE///////////////////////////////
            // affiche les balles
            foreach (Ammo ammoShot in ammoShotList)
            {
                playground.ShowAmmo(ammoShot);
            }
            // affiche les enemies
            foreach (Enemy nbrEnemy in nbrEnemyList)
            {
                playground.ShowEnemie(nbrEnemy);
            }
            // affiche le joueur
            playground.ShowPlayer(player);
            // affiche le score
            playground.ShowScore(score);
            // affiche le nombre de munition
            playground.ShowAmmo(player);

            // va ajouter des ennemies toutes les 200 frames
            if (frameNumber == 200)
            {
                for (int i = 0; i < numberEnemies.Next(5, 11); i++)
                {
                    nbrEnemyList.Add(new Enemy(i * 5 + 50));
                }
                frameNumber = 0;
            }

            // vérifie si le joueur a perdu
            foreach (Enemy nbrEnemy in nbrEnemyList)
            {
                if (nbrEnemy._y == player._y)
                {
                    gameFinish = true;
                }
            }
            if (ammoShotList.Count == 0 && player.chargerAmmo.Count == 0)
            {
                gameFinish = true;
            }

            frameNumber++;
            Thread.Sleep(3);
        }
        while (!gameFinish);

        /////////////////LOSQUE LE JOUEUR A PERDU////////////////
        // va montrer l'écran de game over
        Console.Clear();
        playground.ShowGameOver(score);

        //demande le pseudo pour la base de données
        playground.VisibleCursor();
        player._name = Console.ReadLine();
        playground.NotVisibleCursor();

        // va insérer le score et le pseudo dans la base de données
        store.insert(player, score, Config.SCREEN_WIDTH, playground._startMenuHeight);
        Console.ReadLine();
    }

    // montre le classement
    else if (optionChoose == 2)
    {
        playground.ShowClassement(store);
        Console.ReadKey();
    }
    // montre les options
    else if (optionChoose == 3)
    {
        playground.ShowOption();
    }
    // montre les règles
    else if (optionChoose == 4)
    {
        playground.ShowRegles();
    }

    // quitte le programme
    else if (optionChoose == 5)
    {
        Environment.Exit(0);
    }
}
while(true);