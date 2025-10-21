using NaughtyAttributes;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

namespace Game.GridSystem
{
    public partial class GridData
    {
        public void Editor_SetDatas(IEnumerable<CellData> datas)
        {
            _dataList.Clear();
            _dataList.AddRange(datas);

            // Save
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssetIfDirty(this);
        }
        
        [Button("Assign Datas")]
        private void Editor_AssignDatas()
        {
            string directory = Path.GetDirectoryName(AssetDatabase.GetAssetPath(this));
            directory = Path.Combine(directory, "Content");

            // Assign all cell datas found under "Content" subfolder
            string[] guids = AssetDatabase.FindAssets($"t:{nameof(CellData)}", new string[]
            {
                directory
            });

            _dataList.Clear();
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                CellData data = AssetDatabase.LoadAssetAtPath<CellData>(path);
                _dataList.Add(data);
            }

            // Save
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssetIfDirty(this);
        }
    }
}
