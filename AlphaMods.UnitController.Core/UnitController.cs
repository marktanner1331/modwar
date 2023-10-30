using AlphaMods.UnitController.Interfaces;
using AlphaMods.Utility.CommandDispatcher.Interfaces;

namespace AlphaMods.UnitController.Core
{
    public class UnitController : IUnitController
    {
        private Dictionary<string, ISubUnitController> subUnitControllers;
        private ICommandDispatcher commandDispatcher;

        public UnitController(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;

            subUnitControllers = new Dictionary<string, ISubUnitController>();
            this.commandDispatcher.AddCommandListener<CreateUnitCommand>(CreateUnitCommand.IDENTIFIER, this.CreateUnit);
        }

        private void CreateUnit(CreateUnitCommand command)
        {
            subUnitControllers[command.UnitTypeIdentifier].CreateUnit(command);
        }

        public void AddSubUnitController(ISubUnitController subUnitController)
        {
            subUnitControllers.Add(subUnitController.GetUnitTypeIdentifier(), subUnitController);
        }

        public CreateUnitCommand GenerateCreateUnitCommand(string unitTypeIdentifier)
        {
            return subUnitControllers[unitTypeIdentifier].GenerateCreateUnitCommand();
        }

        public IEnumerable<string> ListAllUnitTypeIdentifiers()
        {
            return subUnitControllers.Keys;
        }
    }
}