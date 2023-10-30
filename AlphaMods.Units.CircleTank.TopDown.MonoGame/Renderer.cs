using AlphaMods.Renderer.Layered.MonoGame;

namespace AlphaMods.Units.CircleTank.TopDown.MonoGame
{
    internal class Renderer : IRenderLayer
    {
        private MonoGameRenderer renderer;
        private CircleTankUnitController controller;

        public Renderer(MonoGameRenderer renderer, CircleTankUnitController controller)
        {
            this.renderer = renderer;
            this.renderer.AddLayer(this, LayerDepth.UNITS);
            this.controller = controller;
        }

        public void Load()
        {
            
        }

        public void RenderMainGameLayer()
        {
            
        }

        public void RenderMinimapLayer()
        {
            
        }
    }
}