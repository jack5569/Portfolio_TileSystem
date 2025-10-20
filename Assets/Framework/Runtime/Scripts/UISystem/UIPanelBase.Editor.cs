using NaughtyAttributes;

namespace J_Framework.UI
{
    public abstract partial class UIPanelBase
    {
#if UNITY_EDITOR

        [Button("Set to showed state")]
        private void Editor_SetToShowedState()
        {
            _contentController.Editor_SetToShowedState();
            _backBgController.Editor_SetToShowedState();
        }

        [Button("Set to hidden state")]
        private void Editor_SetToHiddenState()
        {
            _contentController.Editor_SetToHiddenState();
            _backBgController.Editor_SetToHiddenState();
        }

#endif
    }
}