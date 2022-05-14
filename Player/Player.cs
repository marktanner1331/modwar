using ModWar.interfaces;
using OpenTK;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Player
{
    class Player : GameWindow
    {
        private readonly IGameRenderer gameRenderer;

        public Player(IGameRenderer gameRenderer) : base(GetGameWindowSettings(), GetNativeWindowSettings())
        {
            this.gameRenderer = gameRenderer;
        }

        private static GameWindowSettings GetGameWindowSettings()
        {
            return new GameWindowSettings();
        }

        private static NativeWindowSettings GetNativeWindowSettings()
        {
            return new NativeWindowSettings
            {
                Title = "ModWar"
            };
        }
    }
}
