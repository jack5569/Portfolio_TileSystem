using UnityEngine;

namespace Game.GridSystem
{
    public interface ICustomGridClient
    {
        Vector2Int GetNearestCellFromWorldPosition(Vector2 worldPosition);
        Vector2 GetWorldPositionOfCell(Vector2 position);

        void HandlePlaceableEditModePlaceablePositionUpdate(GridPlaceable placeable);
        void HandlePlaceableEditModeConfirmPlaceablePosition(GridPlaceable placeable);
    }
}