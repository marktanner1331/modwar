using System;
using ModWar;

namespace ModWar.Player
{
    class Program
    {
        static void Main(string[] args)
        {
            ModLoader loader = new ModLoader();
            loader.LoadMods(
                "AlphaMods.GameEngine.Core",
                "AlphaMods.Hud.Core",
                "AlphaMods.Renderer.MonoGame",
                "AlphaMods.Maps.EmptyMap.MonoGame");
            loader.Get<IGameStart>().Start();
        }
    }
}
