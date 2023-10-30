using AlphaMods.UnitController.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Units.CircleTank.TopDown.MonoGame
{
    public class CircleTankUnit : IUnit
    {
        public string UnitTypeIdentifier { get; set; }

        public int UnitId { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Rotation { get; set; }

        public int Player { get; set; }

        public void SetPosition(double x, double y)
        {
            
            X = x;
            Y = y;
        }
    }
}
