using UnityEngine;

namespace Game.GridSystem
{
    public class GridSystem : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CustomGrid _grid;

        public ICustomGridClient GridClient => _grid;

        public void Load(GridData data)
        {
            _grid.Load(data);
        }
    }
}