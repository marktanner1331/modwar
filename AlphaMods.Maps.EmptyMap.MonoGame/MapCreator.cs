using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SixLabors.ImageSharp.Drawing.Processing;

namespace AlphaMods.Maps.EmptyMap.MonoGame
{
    internal class MapCreator
    {
        public Texture2D CreateMap(GraphicsDevice graphicsDevice)
        {
            using (var image = new Image<Rgba32>(800, 600))
            {
                image.Mutate(x =>
                {
                    x.Fill(Color.White);
                    x.DrawLines(
                        Color.Black,
                        2,
                        new Point(0, 0),
                        new Point(800, 0),
                        new Point(800, 600),
                        new Point(0, 600),
                        new Point(0, 0));

                    for (int i = 1; i < 16; i++)
                    {
                        x.DrawLines(
                            Color.Black,
                            1,
                            new Point(50 * i, 0),
                            new Point(50 * i, 600));
                    }

                    for (int i = 1; i < 12; i++)
                    {
                        x.DrawLines(
                            Color.Black,
                            1,
                            new Point(0, 50 * i),
                            new Point(800, 50 * i));
                    }
                });

                byte[] buffer = new byte[800 * 600 * 4];
                image.CopyPixelDataTo(buffer);

                Texture2D tex = new Texture2D(graphicsDevice, 800, 600, false, SurfaceFormat.Color);
                tex.SetData(buffer);

                return tex;
            }
        }
    }
}
