using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Renderer.Interfaces
{
    public interface IRenderLayer
    {
        void Load();
        void RenderGame();
        void RenderMinimap();
    }
}
