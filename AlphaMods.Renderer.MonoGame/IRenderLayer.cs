using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Renderer.TopDown.MonoGame
{
    public interface IRenderLayer
    {
        void Load();
        void RenderMainGameLayer();
        void RenderMinimapLayer();
    }
}
