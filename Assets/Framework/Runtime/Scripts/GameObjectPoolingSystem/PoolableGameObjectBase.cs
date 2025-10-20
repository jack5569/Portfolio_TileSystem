using UnityEngine;

namespace J_Framework.GameObjectPoolingSystem
{
    public abstract class PoolableGameObjectBase : MonoBehaviour
    {
        private GameObjectPool _pool;

        public void InitializePool(GameObjectPool pool)
        {
            _pool = pool;
        }

        public void Release()
        {
            _pool.Push(this);
        }
    }
}
