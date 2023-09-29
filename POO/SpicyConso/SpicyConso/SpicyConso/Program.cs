using Model;
using Display;
using System.Numerics;

Playground playground = new Playground();

Cursor cursor = new Cursor();
playground.Init(cursor);


//récupère l'input du clavier
ConsoleKeyInfo keyPressed;



List<Ammo> ammoShotList = new List<Ammo>();
List<Enemy> nbrEnemyList = new List<Enemy>();
Player player = new Player();

int frameNumber = 0;
int optionChoose = 0;

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
                if(cursor._y == playground._startMenuHeight + 1)
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
    for (int i = 0; i < 10; i++)
    {
        nbrEnemyList.Add(new Enemy(i * 5 + 50));
    }


    while (true)
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
                    ammoShotList.Add(new Ammo(player._x + 2));
                    break;
                default:
                    break;
            }
        }

        //update
        player.PlayerMovementUpdate(0);
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
                            break;
                        }
                    }
                }
            }
        }
        if (frameNumber % 5 == 0)
        {
            //enemies go down
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

            //enemies update
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
        if (frameNumber == 100)
        {
            frameNumber = 0;
        }
        frameNumber++;
        Thread.Sleep(1);
    }
}
else if (optionChoose == 2)
{
    playground.ShowClassement();
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