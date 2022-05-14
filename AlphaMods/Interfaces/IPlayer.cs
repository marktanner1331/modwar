using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AlphaMods.Interfaces
{
    public abstract class IPlayer
    {
        public string Name;

        public PointF StartingPosition;

        protected IPlayer(string name, PointF startingPosition)
        {
            Name = name;
            StartingPosition = startingPosition;
        }
    }
}
