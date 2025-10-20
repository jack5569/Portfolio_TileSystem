using UnityEngine;
using UnityEngine.Tilemaps;

namespace GridSystem
{
    public class Grid : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private UnityEngine.Grid _grid;
        [SerializeField] private Tilemap _tilemap;

        public void Load(GridData data)
        {
            _tilemap.ClearAllTiles();
            foreach (CellData cellData in data.GetAll())
                _tilemap.SetTile(new Vector3Int(cellData.Position.x, cellData.Position.y), cellData.TileData.Tile);
        }
    }
}