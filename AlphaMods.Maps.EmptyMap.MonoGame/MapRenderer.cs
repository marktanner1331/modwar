using AlphaMods.Renderer.Interfaces;
using AlphaMods.Renderer.MonoGame;
using Microsoft.Xna.Framework.Graphics;
using ModWar;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Maps.EmptyMap.MonoGame
{
    public class MapRenderer : IRenderLayer
    {
        private MonoGameRenderer renderer;
        private Texture2D? texture;

        public MapRenderer(MonoGameRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void Load()
        {
            MapCreator mapCreator = new MapCreator();
            texture = mapCreator.CreateMap(renderer.GraphicsDevice);
        }

        public void RenderGame()
        {
            
        }

        public void RenderMinimap()
        {
            
        }
    }
}
