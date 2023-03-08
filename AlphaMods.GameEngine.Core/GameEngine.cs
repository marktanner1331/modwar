using AlphaMods.GameEngine.Interfaces;
using AlphaMods.Renderer.Interfaces;

namespace AlphaMods.GameEngine.Core
{
    public class GameEngine : IGameEngine
    {
        private IRenderer renderer;

        public GameEngine(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void Start()
        {
            renderer.Start();
        }
    }
}