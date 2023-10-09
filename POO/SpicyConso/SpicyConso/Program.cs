using Model;
using Display;
using Storage;
using System.Numerics;

Playground playground = new Playground();


Cursor cursor = new Cursor();
Store store = new Store();

playground.Init(cursor);


//récupère l'input du clavier
ConsoleKeyInfo keyPressed;



List<Ammo> ammoShotList = new List<Ammo>();
List<Enemy> nbrEnemyList = new List<Enemy>();

int frameNumber = 0;
int optionChoose = 0;
do
{
    Console.Clear();
    do
    {
        optionChoose = 0;
        playground.ShowTitleMainMenu();
        playground.Show(cursor);
        if (Console.KeyAvailable)
        {
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

    if (optionChoose == 1)
    {

        Score score = new Score();
        Player player = new Player();
        Random numberEnemies = new Random();
        bool gameFinish = false;

        for (int i = 0; i < 10; i++)
        {
            nbrEnemyList.Add(new Enemy(i * 5 + 50));
        }
        player.InitPlayer();

        do
        {
            //input
            if (Console.KeyAvailable)
            {
                keyPressed = Console.ReadKey(true);
                switch (keyPressed.Key)
                {
                    case ConsoleKey.A:
                        player.PlayerMovementUpdate(-1 * player._speed);
                        break;
                    case ConsoleKey.D:
                        player.PlayerMovementUpdate(1 * player._speed);
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

            //update ammo
            if (ammoShotList.Count > 0)
            {
                for (int i = ammoShotList.Count - 1; i >= 0; i--)
                {
                    ammoShotList[i].AmmoUpdate();
                    if (ammoShotList[i]._y == 0)
                    {
                        ammoShotList.Remove(ammoShotList[i]);
                    }
                }
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

            //add ammo
            if (player._enemiesKillToGiveAmmo == 5)
            {
                player.AddAmmo(3);
                player._enemiesKillToGiveAmmo = 0;
            }

            //enemies go down
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

            //enemies update
            if (frameNumber % 3 == 0)
            {
                foreach (Enemy nbrEnemy in nbrEnemyList)
                {
                    nbrEnemy.UpdateEnemy();
                }
            }
            Console.Clear();

            //draw
            foreach (Ammo ammoShot in ammoShotList)
            {
                playground.Show(ammoShot);
            }
            foreach (Enemy nbrEnemy in nbrEnemyList)
            {
                playground.Show(nbrEnemy);
            }

            playground.Show(player);
            playground.ShowScore(score);
            playground.ShowAmmo(player);
            if (frameNumber == 200)
            {
                for (int i = 0; i < numberEnemies.Next(1, 10); i++)
                {
                    nbrEnemyList.Add(new Enemy(i * 5 + 50));
                }
                frameNumber = 0;
            }
            frameNumber++;
            Thread.Sleep(3);

            foreach (Enemy nbrEnemy in nbrEnemyList)
            {
                if (nbrEnemy._y == player._y)
                {
                    gameFinish = true;
                }
            }
        }
        while (!gameFinish);
        Console.Clear();
        playground.ShowGameOver(score);
        player._name = Console.ReadLine();
        store.insert(player, score);
        Console.ReadLine();
    }
    else if (optionChoose == 2)
    {
        playground.ShowClassement(store);
        Console.ReadKey();
    }
    else if (optionChoose == 3)
    {
        playground.ShowOption();
    }
    else if (optionChoose == 4)
    {
        playground.ShowRegles();
    }
    else if (optionChoose == 5)
    {
        Environment.Exit(0);
    }
}
while(true);