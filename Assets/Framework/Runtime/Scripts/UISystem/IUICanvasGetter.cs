namespace J_Framework.UI
{
    public interface IUICanvasGetter<TUICanvasBase>
    {
        TUICanvas Get<TUICanvas>() where TUICanvas : TUICanvasBase;
    }
}
