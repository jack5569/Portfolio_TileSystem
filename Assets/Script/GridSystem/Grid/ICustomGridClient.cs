using UnityEngine;

public interface ICustomGridClient
{
    Vector2 GetSnappedPlaceablePositionFromWorldPosition(Vector2 worldPosition);

    Vector2 GetWorldPositionOfCell(Vector2 position);
}
