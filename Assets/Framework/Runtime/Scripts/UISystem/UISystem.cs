using UnityEngine;
using UnityEngine.SceneManagement;

namespace J_Framework.UI
{
    public abstract class UISystem<TUICanvasBase, TUIPanelBase> : MonoSingleton<UISystem<TUICanvasBase, TUIPanelBase>>
        where TUICanvasBase : MonoBehaviour
        where TUIPanelBase : MonoBehaviour
    {
        private UICanvasKeeper<TUICanvasBase> _canvasKeeper = new UICanvasKeeper<TUICanvasBase>();
        private UIPanelKeeper<TUIPanelBase> _panelKeeper = new UIPanelKeeper<TUIPanelBase>();

        public IUICanvasGetter<TUICanvasBase> Canvas => _canvasKeeper;
        public IUIPanelGetter<TUIPanelBase> Panel => _panelKeeper;

        #region MonoBehaviour

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoadedHandler;
            SceneManager.sceneUnloaded += OnSceneUnloadedHandler;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoadedHandler;
            SceneManager.sceneUnloaded += OnSceneUnloadedHandler;
        }

        #endregion

        #region Private methods

        private void RefreshKeepers()
        {
            _canvasKeeper.Refresh();
            _panelKeeper.Refresh();
        }

        #endregion

        #region Scene management events

        private void OnSceneLoadedHandler(Scene scene, LoadSceneMode loadSceneMode)
        {
            RefreshKeepers();
        }

        private void OnSceneUnloadedHandler(Scene scene)
        {
            RefreshKeepers();
        }

        #endregion
    }
}
