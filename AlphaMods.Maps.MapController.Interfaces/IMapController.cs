namespace AlphaMods.Maps.MapController.Interfaces
{
    public interface IMapController
    {
        MapPoint GetStartingPointForPlayer(int playerId);
        MapRectangle GetVisibleTiles();
    }
}