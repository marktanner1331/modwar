using AlphaMods.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AlphaMods.Controllers
{
    class UnitsController : IUnitsController
    {
        private Dictionary<string, List<IUnit>> playerUnits;
        private List<IUnit> selectedUnits;

        private readonly KernelBase kernel;
        private IMapController mapController { get => kernel.Get<IMapController>(); }

        public UnitsController(KernelBase kernel)
        {
            this.kernel = kernel;
            playerUnits = new Dictionary<string, List<IUnit>>();
            selectedUnits = new List<IUnit>();
        }

        public void DeselectAllUnits()
        {
            selectedUnits.Clear();
        }

        public IUnit GetUnitUnderPoint(float x, float y)
        {
            foreach(var pair in playerUnits)
            {
                foreach(var unit in pair.Value)
                {
                    if(unit.HitTest(x, y))
                    {
                        return unit;
                    }
                }
            }

            return null;
        }

        public IEnumerable<IUnit> ListUnitsForPlayer(string playerName)
        {
            if(!playerUnits.ContainsKey(playerName))
            {
                return Enumerable.Empty<IUnit>();    
            }

            return playerUnits[playerName];
        }

        public IEnumerable<IUnit> ListUnitsInAreaForPlayer(string playerName, RectangleF area)
        {
            if (!playerUnits.ContainsKey(playerName))
            {
                yield break;
            }

            foreach(IUnit unit in playerUnits[playerName])
            {
                if(area.Contains(unit.CenterX, unit.CenterY))
                {
                    yield return unit;
                }
            }
        }

        public void MoveSelectedUnitsTo(float x, float y)
        {
            foreach(IUnit unit in selectedUnits)
            {
                unit.Move(x, y);
            }
        }

        public void RegisterUnit(IUnit unit)
        {
            if(playerUnits.ContainsKey(unit.Owner) == false)
            {
                playerUnits.Add(unit.Owner, new List<IUnit>());
            }

            playerUnits[unit.Owner].Add(unit);
        }

        public void SelectUnit(IUnit unit)
        {
            selectedUnits.Clear();
            selectedUnits.Add(unit);
        }

        public void SelectUnits(IEnumerable<IUnit> units)
        {
            selectedUnits.Clear();
            selectedUnits.AddRange(units);
        }
    }
}
