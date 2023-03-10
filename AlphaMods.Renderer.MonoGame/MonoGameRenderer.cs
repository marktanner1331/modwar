using Microsoft.Xna.Framework;
using ModWar;

namespace AlphaMods.Renderer.TopDown.MonoGame
{
    public delegate void Render();

    public class MonoGameRenderer : Game, IGameStart
    {
        private List<Tuple<LayerDepth, IRenderLayer>> _layers;
        private Render? _root;

        public GraphicsDeviceManager Graphics;

        public int MapWidth;
        public int MapHeight;

        public MonoGameRenderer()
        {
            _layers = new List<Tuple<LayerDepth, IRenderLayer>>();
            Graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
        }

        /// <summary>
        /// returns the area of the screen that the game should render to
        /// </summary>
        public Rectangle GetGameBounds()
        {
            return new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        }

        /// <summary>
        /// returns the area of the map that should be rendered
        /// </summary>
        public Rectangle GetMapArea()
        {
            double xScale = (double)GraphicsDevice.Viewport.Width / MapWidth;
            double yScale = (double)GraphicsDevice.Viewport.Height / MapHeight;
            double scale = Math.Max(xScale, yScale);

            return new Rectangle(
                0,
                0,
                (int)(GraphicsDevice.Viewport.Width * scale),
                (int)(GraphicsDevice.Viewport.Height * scale));
        }

        public void AddLayer(IRenderLayer layer, LayerDepth layerDepth)
        {
            _layers.Add(new Tuple<LayerDepth, IRenderLayer>(layerDepth, layer));
            _layers.Sort((x, y) => x.Item1 - y.Item1);
        }

        public void RenderMainGameLayers()
        {
            foreach (var layer in _layers)
            {
                layer.Item2.RenderMainGameLayer();
            }
        }

        public void RenderMinimap()
        {
            foreach (var layer in _layers)
            {
                layer.Item2.RenderMinimapLayer();
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