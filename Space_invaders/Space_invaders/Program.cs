using Space_invaders;

Console.CursorVisible = false;
Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);

//récupère l'input du clavier
ConsoleKeyInfo keyPressed;

Player player = new Player();
while (true)
{
    player.Update(0);
    if (Console.KeyAvailable)
    {
        //lit l'input
        keyPressed = Console.ReadKey(true);
        switch (keyPressed.Key)
        {
            case ConsoleKey.A:
                player.Update(-1);
                break;
            case ConsoleKey.D:
                player.Update(1);
                break;
        }
    }

    Console.Clear();
    player.Show();
    Thread.Sleep(50);
}