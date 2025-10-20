using System.Collections.Generic;
using UnityEngine;

namespace J_Framework
{
    public class DataCollectionBase<T> : ScriptableObject where T : DataBase
    {
        [SerializeField] private T[] _datas;

        private Dictionary<string, T> _dictionaryData;

        #region MonoBehaviour

        private void OnEnable()
        {
            Initialize();
        }

        #endregion

        #region Public methods

        public bool HasData(string id) { return _dictionaryData.ContainsKey(id); }

        public T[] GetDatas() { return _datas; }

        public T GetData(string id)
        {
            if (!_dictionaryData.ContainsKey(id))
            {
                Debug.LogError($"{nameof(T)} data of id {id} cannot be found! Null returned!");
                return null;
            }

            return _dictionaryData[id];
        }

        #endregion

        #region Private methods

        private void Initialize()
        {
            _dictionaryData = new Dictionary<string, T>();

            // Return if null (Will happpen as soon as a new data collection created in editor)
            if (_datas == null)
                return;

            foreach (T data in _datas)
                _dictionaryData.TryAdd(data.Id, data);
        }

        #endregion
    }
}
