using System.Collections.Generic;
using System.IO;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.GridSystem
{
    public class GridDataEditor : MonoBehaviour
    {
#if UNITY_EDITOR

        [Header("References")]
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private TileData[] _tileDatas;

        [Header("Data")]
        [SerializeField] private GridData _gridDataToLoad;

        private bool _isGridDataToLoadAssigned => _gridDataToLoad != null;

        [Button("Load")]
        [EnableIf(nameof(_isGridDataToLoadAssigned))]
        private void Editor_Load()
        {
            _tilemap.ClearAllTiles();
            foreach (CellData data in _gridDataToLoad.GetAll())
            {
                Vector3Int position = new Vector3Int(data.Position.x, data.Position.y);
                _tilemap.SetTile(position, data.TileData.Tile);
            }
        }

        [Button("Clear")]
        private void Editor_Clear()
        {
            _tilemap.ClearAllTiles();
        }

        [Button("Export")]
        private void Editor_Export()
        {
            string outputDirectory = EditorUtility.OpenFolderPanel("Select export directory", "Assets", "Export Directory");
            outputDirectory = FileUtil.GetProjectRelativePath(outputDirectory);
            if (Directory.Exists(outputDirectory))
            {
                string cellDataOutputDirectory = Path.Combine(outputDirectory, "Content");
                Directory.CreateDirectory(cellDataOutputDirectory);

                List<CellData> listExportedCellDatas = new List<CellData>();
                TileBase[] tiles = _tilemap.GetTilesBlock(_tilemap.cellBounds);
                for (int i = 0; i < _tilemap.cellBounds.size.x; i++)
                {
                    for (int j = 0; j < _tilemap.cellBounds.size.y; j++)
                    {
                        TileBase tile = tiles[i + j * _tilemap.cellBounds.size.x];
                        if (!tile)
                            continue;

                        TileData resultTileData = null;
                        Vector2Int resultPosition = new Vector2Int(_tilemap.cellBounds.xMin + i, _tilemap.cellBounds.yMin + j);
                        foreach (TileData tileData in _tileDatas)
                        {
                            if (tileData.Tile == tile)
                            {
                                resultTileData = tileData;
                                break;
                            }
                        }

                        // Output cell data
                        listExportedCellDatas.Add(Editor_OutputCellData(cellDataOutputDirectory, resultTileData, resultPosition));
                    }
                }

                // Output grid data
                Editor_OutputGridData(outputDirectory, listExportedCellDatas);

                // Ping
                EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(outputDirectory));
            }

            CellData Editor_OutputCellData(string directory, TileData data, Vector2Int position)
            {
                string path = Path.Combine(directory, $"CellData_[{position.x},{position.y}].asset");
                CellData asset = ScriptableObject.CreateInstance<CellData>();
                asset.Editor_SetTileData(data);
                asset.Editor_SetPosition(position);

                AssetDatabase.CreateAsset(asset, path);
                return asset;
            }

            GridData Editor_OutputGridData(string directory, IEnumerable<CellData> datas)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                string path = Path.Combine(directory, $"GridData_{directoryInfo.Name}.asset");
                GridData asset = ScriptableObject.CreateInstance<GridData>();
                asset.Editor_SetDatas(datas);

                AssetDatabase.CreateAsset(asset, path);
                return asset;
            }
        }

#endif
    }
}