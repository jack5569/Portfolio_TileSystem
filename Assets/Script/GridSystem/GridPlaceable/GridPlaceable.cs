using System.Collections.Generic;
using UnityEngine;

namespace Game.GridSystem
{
    public class GridPlaceable : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Vector2Int _size;

        [Header("References")]
        [SerializeField] private SpriteRenderer _spriteRendererVisual;

        public Vector2Int BoundsMin => _cellPosition;
        public Vector2Int BoundsMax => _cellPosition + _size - Vector2Int.one;
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

        public IEnumerable<Vector2Int> GetOccupiedCells()
        {
            List<Vector2Int> listResult = new List<Vector2Int>();
            for (int i = 0; i < _size.x; i++)
            {
                for (int j = 0; j < _size.y; j++)
                    listResult.Add(BoundsMin + new Vector2Int(i, j));
            }

            return listResult;
        }

        public bool IsOverlappingWith(params GridPlaceable[] others)
        {
            foreach (GridPlaceable other in others)
            {
                bool isHorizontalOverlapping = !(BoundsMax.y < other.BoundsMin.y || BoundsMin.y > other.BoundsMax.y);
                bool isVerticalOverlapping = !(BoundsMax.x < other.BoundsMin.x || BoundsMin.x > other.BoundsMax.x);
                if (isHorizontalOverlapping && isVerticalOverlapping)
                    return true;
            }

            return false;
        }
    }
}