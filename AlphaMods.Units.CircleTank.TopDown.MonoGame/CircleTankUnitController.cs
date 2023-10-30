using AlphaMods.UnitController.Interfaces;
using AlphaMods.Utility.CommandDispatcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Units.CircleTank.TopDown.MonoGame
{
    internal class CircleTankUnitController : ISubUnitController
    {
        private IUnitController unitController;
        internal List<CircleTankUnit> Units;

        public CircleTankUnitController(IUnitController unitController)
        {
            this.unitController = unitController;
            this.unitController.AddSubUnitController(this);

            this.Units = new List<CircleTankUnit>();
        }

        public void CreateUnit(CreateUnitCommand command)
        {
            Units.Add(new CircleTankUnit
            {
                Y = command.Y,
                X = command.X,
                Player = command.Player,
                Rotation = command.Rotation,
                UnitId = command.UnitId,
                UnitTypeIdentifier = command.UnitTypeIdentifier
            });
        }

        public CreateUnitCommand GenerateCreateUnitCommand()
        {
            return new CreateUnitCommand(GetUnitTypeIdentifier());
        }

        public string GetUnitTypeIdentifier()
        {
            return "AlphaMods.Units.CircleTank";
        }
    }
}
