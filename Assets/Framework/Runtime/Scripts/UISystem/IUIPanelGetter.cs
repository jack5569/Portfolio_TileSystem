namespace J_Framework.UI
{
    public interface IUIPanelGetter<TUIPanelBase>
    {
        TUIPanel Get<TUIPanel>() where TUIPanel : TUIPanelBase;
    }
}
