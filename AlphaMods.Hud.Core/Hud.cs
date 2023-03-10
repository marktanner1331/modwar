using AlphaMods.Renderer.TopDown.MonoGame;

namespace AlphaMods.Hud.Core
{
    public class Hud
    {
        private MonoGameRenderer renderer;

        public Hud(MonoGameRenderer renderer)
        {
            this.renderer = renderer;
            this.renderer.SetRoot(this.Render);
        }

        public void Render()
        {
            renderer.RenderMainGameLayers();
        }
    }
}