using AlphaMods.Utility.CommandDispatcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.UnitController.Interfaces
{
    public class CreateUnitCommand : ICommand, IUnit
    {
        public const string IDENTIFIER = "AlphaMods.UnitController.CreateUnit";

        public string Identifier => IDENTIFIER;
        public string UnitTypeIdentifier { get; }
        public int UnitId { get; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Rotation { get; }
        public int Player { get; }

        public CreateUnitCommand(string unitTypeIdentifier)
        {
            UnitTypeIdentifier = unitTypeIdentifier;
        }

        public void SetPosition(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
