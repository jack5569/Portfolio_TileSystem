using UnityEngine;

namespace J_Framework.GameObjectPoolingSystem
{
    [CreateAssetMenu(menuName = "Game Object Pooling System/Pool Specification")]
    public class GameObjectPoolSpecification : ScriptableObject
    {
        [SerializeField] private GameObjectPoolKey _key;
        [SerializeField] private PoolableGameObjectBase _prefab;
        [SerializeField] private int _startingPoolSize;

        public string Key => _key.Value;
        public PoolableGameObjectBase Prefab => _prefab;
        public int StartingPoolSize => _startingPoolSize;
    }
}
