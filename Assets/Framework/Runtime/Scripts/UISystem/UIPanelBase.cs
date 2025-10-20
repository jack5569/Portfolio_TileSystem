using UnityEngine;

namespace J_Framework.UI
{
    public abstract partial class UIPanelBase : MonoBehaviour
    {
        [Header("Reference - Base")]
        [SerializeField] UIPanelContentController _contentController;
        [SerializeField] UIPanelBackBgController _backBgController;

        #region Public methods

        public void Show()
        {
            _contentController.Show(OnShowed);
            _backBgController.Show();
            OnShow();
        }

        public void Hide()
        {
            _contentController.Hide(OnHidden);
            _backBgController.Hide();
            OnHide();
        }

        #endregion

        #region Protected methods

        protected abstract IUIPanelBaseEventInvoker GetBaseEventInvoker();

        protected virtual void OnShow() { GetBaseEventInvoker().InvokeOnShow(this); }
        protected virtual void OnHide() { GetBaseEventInvoker().InvokeOnHide(this); }
        protected virtual void OnShowed() { GetBaseEventInvoker().InvokeOnShowed(this); }
        protected virtual void OnHidden() { GetBaseEventInvoker().InvokeOnHidden(this); }

        #endregion
    }
}
