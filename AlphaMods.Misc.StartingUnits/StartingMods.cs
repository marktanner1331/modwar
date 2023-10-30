using AlphaMods.AI.UnitFormation.Interfaces;
using AlphaMods.Maps.MapController.Interfaces;
using AlphaMods.PlayerController.Interfaces;
using AlphaMods.UnitController.Interfaces;
using AlphaMods.Utility.CommandDispatcher.Interfaces;

namespace AlphaMods.Misc.StartingUnits
{
    internal class StartingMods
    {
        private IUnitController unitController;
        private IFormationController formationController;
        private ICommandDispatcher commandDispatcher;
        private IMapController mapController;
        private IPlayerController playerController;

        public StartingMods(IUnitController unitController, IFormationController formationController, ICommandDispatcher commandDispatcher, IMapController mapController, IPlayerController playerController)
        {
            this.unitController = unitController;
            this.formationController = formationController;
            this.commandDispatcher = commandDispatcher;
            this.mapController = mapController;
            this.playerController = playerController;
        }

        public void AddUnits()
        {
            List<string> unitIdentifiers = this.unitController.ListAllUnitTypeIdentifiers().ToList();

            List<CreateUnitCommand> commands = new List<CreateUnitCommand>();
            for (int playerId = 0; playerId < playerController.NumPlayers; playerId++)
            {
                for (int i = 0; i < 5; i++)
                {
                    commands.Add(unitController.GenerateCreateUnitCommand(unitIdentifiers.First()));
                }

                MapPoint playerPoint = mapController.GetStartingPointForPlayer(playerId);
                formationController.GenerateFormationAtPoint(playerPoint, commands);

                foreach(var command in commands)
                {
                    commandDispatcher.DispatchCommand(command);
                }
            }
        }
    }
}