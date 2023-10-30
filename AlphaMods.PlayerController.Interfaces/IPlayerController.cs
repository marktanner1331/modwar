namespace AlphaMods.PlayerController.Interfaces
{
    public interface IPlayerController
    {
        int NumPlayers { get; }
        string HexColorForPlayer(int playerId);
    }
}