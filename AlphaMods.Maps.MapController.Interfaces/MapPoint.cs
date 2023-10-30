using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Maps.MapController.Interfaces
{
    public class MapPoint
    {
        public int X;
        public int Y;

        public MapPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public MapPoint Clone()
        {
            return new MapPoint(X, Y);
        }
    }
}
