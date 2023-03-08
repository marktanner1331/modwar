using AlphaMods.Hud.Interfaces;
using AlphaMods.Renderer.Interfaces;

namespace AlphaMods.Hud.Core
{
    public class Hud : IHud
    {
        private IRenderer renderer;

        public Hud(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void Render()
        {
            renderer.RenderGame();
        }
    }
}