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
                "AlphaMods.Hud.Core",
                "AlphaMods.Renderer.TopDown.MonoGame",
                "AlphaMods.Maps.EmptyMap.MonoGame");
            loader.Get<IGameStart>().Start();
        }
    }
}
