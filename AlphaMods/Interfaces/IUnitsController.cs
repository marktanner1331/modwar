using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AlphaMods.Interfaces
{
    public interface IUnitsController
    {
        void RegisterUnit(IUnit unit);

        IEnumerable<IUnit> ListUnitsForPlayer(string playerName);

        void SelectUnit(IUnit unit);

        void SelectUnits(IEnumerable<IUnit> units);

        IEnumerable<IUnit> ListUnitsInAreaForPlayer(string playerName, RectangleF area);

        void DeselectAllUnits();

        IUnit GetUnitUnderPoint(float x, float y);

        void MoveSelectedUnitsTo(float x, float y);
    }
}
