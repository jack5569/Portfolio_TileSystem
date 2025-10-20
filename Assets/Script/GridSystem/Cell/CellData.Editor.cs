using UnityEditor;
using UnityEngine;

namespace GridSystem
{
    public partial class CellData
    {
#if UNITY_EDITOR

        public void Editor_SetTileData(TileData value)
        {
            _tileData = value;
            EditorUtility.SetDirty(this);
        }

        public void Editor_SetPosition(Vector2Int value)
        {
            _position = value;
            EditorUtility.SetDirty(this);
        }

#endif
    }
}
