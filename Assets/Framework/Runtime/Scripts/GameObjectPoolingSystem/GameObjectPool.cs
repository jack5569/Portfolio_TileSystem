using System.Collections.Generic;
using UnityEngine;

namespace J_Framework.GameObjectPoolingSystem
{
    public class GameObjectPool : MonoBehaviour
    {
        public string Key => _key;

        private string _key;
        private PoolableGameObjectBase _prefab;

        private Stack<PoolableGameObjectBase> _stack = new Stack<PoolableGameObjectBase>();

        #region Public methods

        public void Initialize(GameObjectPoolSpecification specification)
        {
            _key = specification.Key;
            _prefab = specification.Prefab;
            for (int i = 0; i < specification.StartingPoolSize; i++)
                Push(Create());
        }

        public PoolableGameObjectBase Get()
        {
            if (_stack.Count <= 0)
                Push(Create());

            PoolableGameObjectBase instance = _stack.Pop();
            instance.transform.SetParent(null);
            instance.gameObject.SetActive(true);
            return instance;
        }

        public TPoolableGameObject Get<TPoolableGameObject>() where TPoolableGameObject : PoolableGameObjectBase { return (TPoolableGameObject)Get(); }

        public void Push(PoolableGameObjectBase instance)
        {
            if (!instance)
                return;

            _stack.Push(instance);
            instance.gameObject.SetActive(false);
            instance.transform.SetParent(transform);
        }

        #endregion

        #region Private methods

        private PoolableGameObjectBase Create()
        {
            PoolableGameObjectBase instance = Instantiate(_prefab, transform);
            instance.InitializePool(this);
            return instance;
        }

        #endregion
    }
}
