using UnityEngine;

namespace J_Framework
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance => _instance;

        [Header("Settings - Singleton")]
        [SerializeField] private bool _dontDestroyOnLoad = true;

        protected virtual void Awake()
        {
            if (_instance != null && _instance != GetComponent<T>())
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = GetComponent<T>();
                if (_dontDestroyOnLoad)
                    DontDestroyOnLoad(gameObject);
            }
        }
    }
}
