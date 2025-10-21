using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Tilemaps;

namespace Game.GridSystem
{
    public class CustomGrid : MonoBehaviour, ICustomGridClient
    {
        [Header("References")]
        [SerializeField] private Grid _grid;
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tilemap _tilemapHighlight;

        [Header("Data")]
        [SerializeField] private Tile _placeableTile;
        [SerializeField] private Tile _unplaceableTile;

        private Dictionary<string, TileData> _dictionaryTileData = new Dictionary<string, TileData>();

        private Dictionary<Vector2Int, RuntimeCellInfo> _dictionaryCellInfo = new Dictionary<Vector2Int, RuntimeCellInfo>();
        private List<GridPlaceable> _listPlaceables = new List<GridPlaceable>();

        private List<Vector2Int> _listPlaceableEditModeAffectedCell = new List<Vector2Int>();

        #region Public methods

        public void Load(GridData data)
        {
            _tilemap.ClearAllTiles();
            foreach (CellData cellData in data.GetAll())
            {
                _dictionaryTileData.TryAdd(cellData.TileData.Id, cellData.TileData);
                _tilemap.SetTile(cellData.Position.ToVector3Int(), cellData.TileData.Tile);
                _dictionaryCellInfo.Add(cellData.Position, new RuntimeCellInfo(cellData.TileData.Id, cellData.Position));
            }
        }

        #endregion

        #region ICustomGridClient

        public Vector2Int GetNearestCellFromWorldPosition(Vector2 worldPosition)
        {
            Vector3Int nearestCell = _grid.WorldToCell(worldPosition);
            return new Vector2Int(nearestCell.x, nearestCell.y);
        }

        public Vector2 GetWorldPositionOfCell(Vector2 position)
        {
            return _grid.CellToLocalInterpolated(position);
        }

        public void HandlePlaceableEditModePlaceablePositionUpdate(GridPlaceable placeable)
        {
            RevertPlaceableEditModeAffectedCells();

            HashSet<Vector2Int> placeableCellSet = new HashSet<Vector2Int>();
            HashSet<Vector2Int> unplacableCellSet = new HashSet<Vector2Int>();
            foreach (Vector2Int cell in placeable.GetOccupiedCells())
            {
                Vector2Int visualCellPosition = GetVisualCellPosition(cell);

                // Skip if the cell doesn't even exist
                if (!IsCellExisting(GetVisualCellPosition(cell)))
                    continue;

                placeableCellSet.Add(visualCellPosition);

                // Overlapping
                foreach (GridPlaceable existingPlaceable in _listPlaceables)
                {
                    if (placeable.IsOverlappingWith(existingPlaceable))
                    {
                        if (existingPlaceable.GetOccupiedCells().Contains(cell))
                        {
                            placeableCellSet.Remove(visualCellPosition);
                            unplacableCellSet.Add(visualCellPosition);
                            continue;
                        }
                    }
                }
            }

            foreach (Vector2Int cell in placeableCellSet)
            {
                _tilemap.SetTile(cell.ToVector3Int(), null);
                _tilemapHighlight.SetTile(cell.ToVector3Int(), _placeableTile);
            }
            foreach (Vector2Int cell in unplacableCellSet)
            {
                _tilemap.SetTile(cell.ToVector3Int(), null);
                _tilemapHighlight.SetTile(cell.ToVector3Int(), _unplaceableTile);
            }
            _listPlaceableEditModeAffectedCell.AddRange(placeableCellSet);
            _listPlaceableEditModeAffectedCell.AddRange(unplacableCellSet);
        }

        public void HandlePlaceableEditModeConfirmPlaceablePosition(GridPlaceable placeable)
        {
            RevertPlaceableEditModeAffectedCells();
            if (IsPlaceable(placeable))
                _listPlaceables.Add(placeable);
            else
                Destroy(placeable.gameObject);
        }

        #endregion

        #region Private methods

        private bool IsCellExisting(Vector2Int cellPosition) { return _dictionaryCellInfo.ContainsKey(cellPosition); }
        private Vector2Int GetVisualCellPosition(Vector2Int cellPosition) { return cellPosition - Vector2Int.one; }

        private bool IsPlaceable(GridPlaceable placeable)
        {
            foreach (Vector2Int cell in placeable.GetOccupiedCells())
            {
                if (!IsCellExisting(GetVisualCellPosition(cell)))
                    return false;
            }

            if (placeable.IsOverlappingWith(_listPlaceables.ToArray()))
                return false;

            return true;
        }

        private void RevertPlaceableEditModeAffectedCells()
        {
            foreach (Vector2Int previousAffectedCell in _listPlaceableEditModeAffectedCell)
            {
                _tilemap.SetTile(previousAffectedCell.ToVector3Int(), _dictionaryTileData[_dictionaryCellInfo[previousAffectedCell].TileId].Tile);
            }
            _tilemapHighlight.ClearAllTiles();

            _listPlaceableEditModeAffectedCell.Clear();
        }

        #endregion
    }
}