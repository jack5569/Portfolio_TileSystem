using System;
using J_Framework.Event;

namespace J_Framework.UI
{
    public interface IUIPanelBaseEventListener : IEventListener
    {
        event Action<UIPanelBase> OnShow;
        event Action<UIPanelBase> OnHide;
        event Action<UIPanelBase> OnShowed;
        event Action<UIPanelBase> OnHidden;
    }
}
