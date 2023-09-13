using Space_invaders;

Console.CursorVisible = false;
Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);

//récupère l'input du clavier
ConsoleKeyInfo keyPressed;

List<Ammo> ammoShotList = new List<Ammo>();

Player player = new Player();
while (true)
{

    if (Console.KeyAvailable)
    {
        //lit l'input
        keyPressed = Console.ReadKey(true);
        switch (keyPressed.Key)
        {
            case ConsoleKey.A:
                player.PlayerMovementUpdate(-1 * player._vitesse);
                break;
            case ConsoleKey.D:
                player.PlayerMovementUpdate(1 * player._vitesse);
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
    
    Console.Clear();
    foreach (Ammo ammoShot in ammoShotList)
    {
        ammoShot.Show();
    }
    player.Show();
    Thread.Sleep(50);
}