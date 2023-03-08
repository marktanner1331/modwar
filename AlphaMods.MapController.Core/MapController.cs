using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.MapController.Core
{
    public class MapController
    {
        public readonly IMapRenderer MapRenderer;

        public MapController(IMapRenderer mapRenderer)
        {
            //TODO: remove this project?
            MapRenderer = mapRenderer;
        }
    }
}
