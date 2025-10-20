using UnityEngine;

namespace GridSystem
{
    [CreateAssetMenu(menuName = "Data/Cell")]
    public partial class CellData : ScriptableObject
    {
        [SerializeField] private TileData _tileData;
        [SerializeField] private Vector2Int _position;

        public TileData TileData => _tileData;
        public Vector2Int Position => _position;
    }
}