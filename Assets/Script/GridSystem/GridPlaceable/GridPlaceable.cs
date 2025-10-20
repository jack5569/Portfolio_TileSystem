using DG.Tweening;
using UnityEngine;

namespace Game.GridSystem
{
    public class GridPlaceable : MonoBehaviour
    {
        private ICustomGridClient _gridClient;

        private Vector2Int _position;

        public void UpdatePosition(Vector2Int position)
        {
            _position = position;
            transform.position = _gridClient.GetWorldPositionOfCell(position);
        }
    }
}