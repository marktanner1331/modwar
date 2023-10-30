using AlphaMods.PlayerController.Interfaces;

namespace AlphaMods.PlayerController.Core
{
    public class PlayerController : IPlayerController
    {
        public int NumPlayers { get; set; }

        public string HexColorForPlayer(int playerId)
        {
            switch(playerId)
            {
                case 0:
                    return "ff0000";
                case 1:
                    return "0000ff";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}