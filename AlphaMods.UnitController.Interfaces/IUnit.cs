using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.UnitController.Interfaces
{
    public interface IUnit
    {
        string UnitTypeIdentifier { get; }
        int UnitId { get; }
        double X { get; }
        double Y { get; }
        double Rotation { get; }
        int Player { get; }

        void SetPosition(double x, double y);
    }
}
