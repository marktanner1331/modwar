using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AlphaMods.Interfaces
{
    public interface IMap
    {
        int Width { get; }
        int Height { get; }

        int MaxPlayers { get; }

        IEnumerable<PointF> PlayerStartingPositions { get; }

        IEnumerable<PointF> GetPathBetweenPoints(PointF start, PointF end);
    }
}
