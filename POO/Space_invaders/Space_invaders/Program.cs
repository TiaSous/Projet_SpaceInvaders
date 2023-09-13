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
                player.PlayerMovementUpdate(-1);
                break;
            case ConsoleKey.D:
                player.PlayerMovementUpdate(1);
                break;
            case ConsoleKey.Spacebar:
                ammoShotList.Add(new Ammo(player._x + 2));
                break;
            default:
                break;
        }
    }

    player.PlayerMovementUpdate(0);
    foreach (Ammo ammoShot in ammoShotList)
    {
        ammoShot.AmmoUpdate();
    }

    
    Console.Clear();
    foreach (Ammo ammoShot in ammoShotList)
    {
        ammoShot.Show();
    }
    player.Show();
    Thread.Sleep(50);
}