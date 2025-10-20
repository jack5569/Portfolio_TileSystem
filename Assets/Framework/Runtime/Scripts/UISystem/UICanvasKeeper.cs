using System;
using System.Collections.Generic;
using UnityEngine;

namespace J_Framework.UI
{
    public class UICanvasKeeper<TUICanvasBase> : IUICanvasGetter<TUICanvasBase> 
        where TUICanvasBase : MonoBehaviour
    {
        private Dictionary<Type, TUICanvasBase> _dictionary = new Dictionary<Type, TUICanvasBase>();

        #region Public methods

        public void Refresh()
        {
            _dictionary.Clear();
            foreach (TUICanvasBase canvas in UnityEngine.Object.FindObjectsByType<TUICanvasBase>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
                _dictionary.Add(canvas.GetType(), canvas);
        }

        public TUICanvas Get<TUICanvas>() where TUICanvas : TUICanvasBase
        {
            if (_dictionary.TryGetValue(typeof(TUICanvas), out TUICanvasBase canvas))
                return canvas as TUICanvas;
            else
                return null;
        }

        #endregion
    }
}
