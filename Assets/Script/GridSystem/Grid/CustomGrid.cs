using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.GridSystem
{
    public class CustomGrid : MonoBehaviour, ICustomGridClient
    {
        [Header("References")]
        [SerializeField] private Grid _grid;
        [SerializeField] private Tilemap _tilemap;

        private Dictionary<Vector2Int, RuntimeCellInfo> _dictionaryCellInfo;
        private List<GridPlaceable> _listPlaceables;

        #region Public methods

        public void Load(GridData data)
        {
            _tilemap.ClearAllTiles();
            foreach (CellData cellData in data.GetAll())
            {
                _tilemap.SetTile(new Vector3Int(cellData.Position.x, cellData.Position.y), cellData.TileData.Tile);
                _dictionaryCellInfo.Add(cellData.Position, new RuntimeCellInfo(cellData.TileData.Id, cellData.Position));
            }
        }

        #endregion

        #region ICustomGridClient

        public Vector2 GetWorldPositionOfCell(Vector2 position) { return _grid.LocalToCellInterpolated(position); }

        #endregion
    }
}