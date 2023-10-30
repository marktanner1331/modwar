using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using AlphaMods.Renderer.Layered.MonoGame;
using AlphaMods.Maps.MapController.Interfaces;

namespace AlphaMods.Maps.EmptyMap.TopDown.MonoGame
{
    public class MapRenderer : IRenderLayer, IMapController
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

        public MapPoint GetStartingPointForPlayer(int playerId)
        {
            switch(playerId)
            {
                case 0:
                    return new MapPoint(1, 6);
                case 1:
                    return new MapPoint(14, 6);
                default:
                    throw new Exception();
            }
        }

        public MapRectangle GetVisibleTiles()
        {
            int tileWidth = 50;
            var mapArea = this.renderer.GetMapArea();
            
        }
    }
}
