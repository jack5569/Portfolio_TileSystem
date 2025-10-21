using UnityEngine;

namespace Game.GridSystem
{
    public class GridPlaceable : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SpriteRenderer _spriteRendererVisual;

        public Vector2Int CellPosition => _cellPosition;

        private ICustomGridClient _gridClient;

        private Vector2Int _cellPosition;

        public void Initialize(ICustomGridClient gridClient)
        {
            _gridClient = gridClient;
        }
        
        public void UpdatePosition(Vector2Int cellPosition)
        {
            _cellPosition = cellPosition;
            transform.position = _gridClient.GetWorldPositionOfCell(new Vector2(_cellPosition.x + 0.5f, _cellPosition.y + 0.5f));
        }
    }
}