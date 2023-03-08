using System;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            ModLoader loader = new ModLoader();
            loader.LoadMods("AlphaMods");

            Player player = new Player();
        }
    }
}
