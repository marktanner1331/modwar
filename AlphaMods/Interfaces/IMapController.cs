using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AlphaMods.Interfaces
{
    public interface IMapController
    {
        void SetMap(IMap map);

        IEnumerable<PointF> GetPathBetweenPoints(PointF start, PointF end);
    }
}
