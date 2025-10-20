using UnityEngine;

namespace J_Framework
{
    public class DataBase : ScriptableObject
    {
        [SerializeField] private string id;

        public string Id => id;
    }
}
