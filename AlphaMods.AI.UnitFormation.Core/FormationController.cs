using AlphaMods.AI.UnitFormation.Interfaces;
using AlphaMods.Maps.MapController.Interfaces;
using AlphaMods.UnitController.Interfaces;

namespace AlphaMods.AI.UnitFormation.Core
{
    public class FormationController : IFormationController
    {
        public void GenerateFormationAtPoint(MapPoint point, IEnumerable<IUnit> units)
        {
            int count = units.Count();
            int squareWidth = (int)Math.Ceiling(Math.Sqrt(count));
            MapPoint topLeft = new MapPoint(point.X - squareWidth / 2, point.Y);
                
            point = topLeft.Clone();

            foreach(IUnit unit in units)
            {
                unit.SetPosition(point.X, point.Y);
                point.X++;
                if(point.X > topLeft.X + squareWidth)
                {
                    point.X = topLeft.X;
                    point.Y++;
                }
            }
        }
    }
}