using System;
using J_Framework.UI;

public class MainUIPanelEventHolder : IMainUIPanelEventListener, IMainUIPanelEventInvoker
{
    public event Action<UIPanelBase> OnShow;
    public event Action<UIPanelBase> OnHide;
    public event Action<UIPanelBase> OnShowed;
    public event Action<UIPanelBase> OnHidden;

    public void InvokeOnShow(UIPanelBase panel) { OnShow?.Invoke(panel); }
    public void InvokeOnHide(UIPanelBase panel) { OnHide?.Invoke(panel); }
    public void InvokeOnShowed(UIPanelBase panel) { OnShowed?.Invoke(panel); }
    public void InvokeOnHidden(UIPanelBase panel) { OnHidden?.Invoke(panel); }
}
