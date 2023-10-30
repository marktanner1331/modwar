using AlphaMods.Maps.MapController.Interfaces;
using AlphaMods.UnitController.Interfaces;

namespace AlphaMods.AI.UnitFormation.Interfaces
{
    public interface IFormationController
    {
        void GenerateFormationAtPoint(MapPoint point, IEnumerable<IUnit> units);
    }
}