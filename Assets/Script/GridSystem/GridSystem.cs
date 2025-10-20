using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public class GridSystem : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Grid _grid;

        [Header("Data")]
        [SerializeField] private GridData _dataToLoad;

        #region MonoBehaviour

        private void Start()
        {
            _grid.Load(_dataToLoad);
        }

        #endregion
    }
}