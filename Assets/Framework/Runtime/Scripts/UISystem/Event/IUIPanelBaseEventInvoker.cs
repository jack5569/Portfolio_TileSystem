namespace J_Framework.UI
{
    public interface IUIPanelBaseEventInvoker
    {
        void InvokeOnShow(UIPanelBase panel);
        void InvokeOnHide(UIPanelBase panel);
        void InvokeOnShowed(UIPanelBase panel);
        void InvokeOnHidden(UIPanelBase panel);
    }
}