using System;
using System.Collections.Generic;
using UnityEngine;

namespace J_Framework.UI
{
    public class UIPanelKeeper<TUIPanelBase> : IUIPanelGetter<TUIPanelBase>
        where TUIPanelBase : MonoBehaviour
    {
        private Dictionary<Type, TUIPanelBase> _dictionary = new Dictionary<Type, TUIPanelBase>();

        #region Public methods

        public void Refresh()
        {
            _dictionary.Clear();
            foreach (TUIPanelBase panel in UnityEngine.Object.FindObjectsByType<TUIPanelBase>(FindObjectsInactive.Include, FindObjectsSortMode.None))
                _dictionary.Add(panel.GetType(), panel);
        }

        public TUIPanel Get<TUIPanel>() where TUIPanel : TUIPanelBase
        {
            if (_dictionary.TryGetValue(typeof(TUIPanel), out TUIPanelBase panel))
                return panel as TUIPanel;
            else
                return null;
        }

        #endregion
    }
}
