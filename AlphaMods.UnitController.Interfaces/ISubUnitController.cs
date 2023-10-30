using AlphaMods.Utility.CommandDispatcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.UnitController.Interfaces
{
    public interface ISubUnitController
    {
        string GetUnitTypeIdentifier();
        CreateUnitCommand GenerateCreateUnitCommand();
        void CreateUnit(CreateUnitCommand command);
    }
}