using System.Collections.Generic;
using GridSystem;
using UnityEngine;

namespace GridSystem
{
    [CreateAssetMenu(menuName = "Data/Grid")]
    public partial class GridData : ScriptableObject
    {
        [SerializeField] private List<CellData> _dataList;

        public IEnumerable<CellData> GetAll() { return _dataList; }
    }
}