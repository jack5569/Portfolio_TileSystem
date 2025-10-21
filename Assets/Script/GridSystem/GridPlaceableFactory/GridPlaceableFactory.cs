using UnityEngine;

namespace Game.GridSystem
{
    public class GridPlaceableFactory : MonoBehaviour
    {
        private ICustomGridClient _gridClient;

        public void Initialize(ICustomGridClient gridClient)
        {
            _gridClient = gridClient;
        }

        public GridPlaceable Create(GridPlaceableData data, Vector2 position)
        {
            GridPlaceable instance = Instantiate(data.Prefab, position, Quaternion.identity);
            instance.Initialize(_gridClient);
            return instance;
        }
    }
}
