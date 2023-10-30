using AlphaMods.Renderer.Layered.MonoGame;

namespace AlphaMods.Hud.Layered.MonoGame
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