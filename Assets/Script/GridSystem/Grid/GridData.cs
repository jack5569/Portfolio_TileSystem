using System.Collections.Generic;
using UnityEngine;

namespace Game.GridSystem
{
    [CreateAssetMenu(menuName = "Data/Grid")]
    public partial class GridData : ScriptableObject
    {
        [SerializeField] private List<CellData> _dataList;

        public IEnumerable<CellData> GetAll() { return _dataList; }
    }
}