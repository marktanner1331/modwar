using System;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            ModLoader loader = new ModLoader();
            loader.LoadMods("Alpha Mods");

            Player player = new Player(loader.GetGameRenderer());
            player.Run();
        }
    }
}
