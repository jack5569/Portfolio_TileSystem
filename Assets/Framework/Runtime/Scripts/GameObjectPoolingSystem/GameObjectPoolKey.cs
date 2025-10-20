using UnityEngine;

namespace J_Framework.GameObjectPoolingSystem
{
    [CreateAssetMenu(menuName = "Game Object Pooling System/Pool Key")]
    public class GameObjectPoolKey : ScriptableObject
    {
        [SerializeField] private string _key;

        public string Value => _key;
    }
}
