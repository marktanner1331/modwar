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
                "AlphaMods.Hud.Layered.MonoGame",
                "AlphaMods.Renderer.Layered.MonoGame",
                "AlphaMods.Maps.EmptyMap.TopDown.MonoGame",
                "AlphaMods.UnitController.Core",
                "AlphaMods.Units.CircleTank.TopDown.MonoGame",
                "AlphaMods.Misc.StartingUnits",
                "AlphaMods.PlayerController.Core",
                "AlphaMods.Utility.CommandDispatcher.Core",
                "AlphaMods.AI.UnitFormation.Core");
            loader.Get<IGameStart>().Start();
        }
    }
}
