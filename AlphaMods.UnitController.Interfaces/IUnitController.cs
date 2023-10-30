using AlphaMods.Utility.CommandDispatcher.Interfaces;

namespace AlphaMods.UnitController.Interfaces
{
    public interface IUnitController
    {
        void AddSubUnitController(ISubUnitController subUnitController);

        IEnumerable<string> ListAllUnitTypeIdentifiers();

        CreateUnitCommand GenerateCreateUnitCommand(string unitTypeIdentifier);
    }
}