using Model;
using Display;
using System.Numerics;

Playground playground = new Playground();
playground.Init();

//récupère l'input du clavier
ConsoleKeyInfo keyPressed;



List<Ammo> ammoShotList = new List<Ammo>();
List<Enemy> nbrEnemyList = new List<Enemy>();
Player player = new Player();


for (int i = 0; i < 10; i++)
{
    nbrEnemyList.Add(new Enemy(i * 5 + 50));
}


while (true)
{

    if (Console.KeyAvailable)
    {
        //lit l'input
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
    }
    foreach (Enemy nbrEnemy in nbrEnemyList)
    {
        if (nbrEnemy._x > ConfigWorld.WORLD_WIDTH_RIGHT || nbrEnemy._x < ConfigWorld.WORLD_WIDTH_LEFT)
        {
            foreach(Enemy nbrEnemy2 in nbrEnemyList)
            {
                playground.Down(nbrEnemy2);
            }
        }
    }
    foreach (Enemy nbrEnemy in nbrEnemyList)
    {
        nbrEnemy.UpdateEnemy();
    }

    Console.Clear();

    foreach (Ammo ammoShot in ammoShotList)
    {
        playground.Show(ammoShot);
    }
    foreach (Enemy nbrEnemy in nbrEnemyList)
    {
        playground.Show(nbrEnemy);
    }
    playground.Show(player);

    Thread.Sleep(100);
}