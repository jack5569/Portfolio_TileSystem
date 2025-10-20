using System.IO;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.GridSystem
{
    public class CellDataOutputter : MonoBehaviour
    {
#if UNITY_EDITOR

        [SerializeField] private TileData[] _tileDatas;

        [SerializeField] private Tilemap _tilemap;

        [Button("Output")]
        private void Editor_Output()
        {
            string outputDirectory = EditorUtility.OpenFolderPanel("Select output directory", "Assets", "Content");
            outputDirectory = FileUtil.GetProjectRelativePath(outputDirectory);
            if (Directory.Exists(outputDirectory))
            {
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
                        Editor_OutputTileData(outputDirectory, resultTileData, resultPosition);
                    }
                }

                EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(outputDirectory));
            }
        }

        private void Editor_OutputTileData(string directory, TileData data, Vector2Int position)
        {
            string path = Path.Combine(directory, $"CellData_[{position.x},{position.y}].asset");
            CellData asset = ScriptableObject.CreateInstance<CellData>();
            asset.Editor_SetTileData(data);
            asset.Editor_SetPosition(position);

            AssetDatabase.SaveAssetIfDirty(asset);
            AssetDatabase.CreateAsset(asset, path);
        }

#endif
    }
}