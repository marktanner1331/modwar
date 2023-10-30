using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Renderer.Layered.MonoGame
{
    public interface IRenderLayer
    {
        void Load();
        void RenderMainGameLayer();
        void RenderMinimapLayer();
    }
}
