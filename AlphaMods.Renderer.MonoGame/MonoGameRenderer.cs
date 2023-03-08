using AlphaMods.Renderer.Interfaces;
using Microsoft.Xna.Framework;
using static AlphaMods.Renderer.Interfaces.IRenderer;

namespace AlphaMods.Renderer.MonoGame
{
    public class MonoGameRenderer : Game, IRenderer
    {
        private List<Tuple<LayerDepth, IRenderLayer>> _layers;
        private Render? _root;

        private GraphicsDeviceManager _graphics;

        public Guid id = Guid.NewGuid();

        public MonoGameRenderer()
        {
            _layers = new List<Tuple<LayerDepth, IRenderLayer>>();
            _graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
        }

        public void AddLayer(IRenderLayer layer, LayerDepth layerDepth)
        {
            _layers.Add(new Tuple<LayerDepth, IRenderLayer>(layerDepth, layer));
            _layers.Sort((x, y) => x.Item1 - y.Item1);
        }

        public void RenderGame()
        {
            foreach (var layer in _layers)
            {
                layer.Item2.RenderGame();
            }
        }

        public void RenderMinimap()
        {
            foreach (var layer in _layers)
            {
                layer.Item2.RenderMinimap();
            }
        }

        public void SetRoot(Render root)
        {
            this._root = root;
        }

        public void Start()
        {
            if(this._root == null)
            {
                throw new Exception("The Renderer does not have a root set");
            }
            this.Run();
        }

        protected override void LoadContent()
        {
            var gd = this.GraphicsDevice;
            foreach (var layer in _layers)
            {
                layer.Item2.Load();
            }

            base.LoadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this._root!();
            base.Draw(gameTime);
        }
    }
}