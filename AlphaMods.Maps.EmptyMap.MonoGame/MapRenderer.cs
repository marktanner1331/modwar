using Microsoft.Xna.Framework.Graphics;
using ModWar;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Color = Microsoft.Xna.Framework.Color;
using AlphaMods.Renderer.TopDown.MonoGame;

namespace AlphaMods.Maps.EmptyMap.MonoGame
{
    public class MapRenderer : IRenderLayer
    {
        private MonoGameRenderer renderer;
        private Texture2D? texture;
        private SpriteBatch? spriteBatch;

        public MapRenderer(MonoGameRenderer renderer)
        {
            this.renderer = renderer;
            this.renderer.MapWidth = 800;
            this.renderer.MapHeight = 600;
            renderer.AddLayer(this, LayerDepth.GROUND);
        }

        public void Load()
        {
            MapCreator mapCreator = new MapCreator();
            texture = mapCreator.CreateMap(renderer.GraphicsDevice);
            spriteBatch = new SpriteBatch(this.renderer.GraphicsDevice);
        }

        public void RenderMainGameLayer()
        {
            spriteBatch.Begin();

            spriteBatch.Draw(texture, renderer.GetGameBounds(), renderer.GetMapArea(), Color.White);

            spriteBatch.End();
        }

        public void RenderMinimapLayer()
        {
            
        }
    }
}
