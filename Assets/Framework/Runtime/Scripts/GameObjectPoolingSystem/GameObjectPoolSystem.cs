using System.Collections.Generic;
using UnityEngine;

namespace J_Framework.GameObjectPoolingSystem
{
    public class GameObjectPoolSystem : MonoSingleton<GameObjectPoolSystem>
    {
        [Header("Settings")]
        [SerializeField] private GameObjectPoolSpecification[] _specifications;

        private Dictionary<string, GameObjectPool> _dictionary = new Dictionary<string, GameObjectPool>();

        #region MonoBehaviour

        protected override void Awake()
        {
            base.Awake();
            foreach (GameObjectPoolSpecification specification in _specifications)
            {
                // Instantiate and parenting
                GameObject gameObjectPool = new GameObject($"GameObjectPool_{specification.Key}");
                gameObjectPool.transform.SetParent(transform);

                // Add component
                GameObjectPool pool = gameObjectPool.AddComponent<GameObjectPool>();
                pool.Initialize(specification);

                _dictionary.Add(specification.Key, pool);
            }
        }

        #endregion

        #region Public methods

        public PoolableGameObjectBase Get(GameObjectPoolKey key) { return _dictionary[key.Value].Get(); }
        public TPoolableGameObject Get<TPoolableGameObject>(GameObjectPoolKey key) where TPoolableGameObject : PoolableGameObjectBase { return _dictionary[key.Value].Get<TPoolableGameObject>(); }

        #endregion
    }
}
