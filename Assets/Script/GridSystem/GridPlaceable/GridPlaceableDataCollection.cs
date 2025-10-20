using UnityEngine;

namespace Game.GridSystem
{
    [CreateAssetMenu(menuName = "Data Collection/Grid Placeable")]
    public class GridPlaceableDataCollection : ScriptableObject
    {
        [SerializeField] private GridPlaceableData[] _datas;

        public GridPlaceableData[] GetAll() { return _datas; }
    }
}
