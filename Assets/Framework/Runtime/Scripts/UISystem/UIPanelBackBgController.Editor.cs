namespace J_Framework.UI
{
    public partial class UIPanelBackBgController
    {
#if UNITY_EDITOR

        public void Editor_SetToShowedState()
        {
            _showData.Editor_SetToEndState(gameObject);
        }

        public void Editor_SetToHiddenState()
        {
            _hideData.Editor_SetToEndState(gameObject);
        }

#endif
    }
}
