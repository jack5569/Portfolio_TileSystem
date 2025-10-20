using UnityEngine;

namespace Game.GridSystem
{
    [CreateAssetMenu(menuName = "Data/Grid Placeable")]
    public class GridPlaceableData : ScriptableObject
    {
        [SerializeField] private GridPlaceable _prefab;
        [SerializeField] private Sprite _sprite;

        public GridPlaceable Prefab => _prefab;
        public Sprite Sprite => _sprite;
    }
}