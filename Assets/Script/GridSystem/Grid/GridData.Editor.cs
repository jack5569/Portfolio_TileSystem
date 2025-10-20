using NaughtyAttributes;
using UnityEditor;
using System.IO;

namespace Game.GridSystem
{
    public partial class GridData
    {
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
