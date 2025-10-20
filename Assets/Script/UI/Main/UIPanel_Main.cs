using UnityEngine;
using J_Framework.UI;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIPanel_Main : UIPanelBase
    {
        [Header("References")]
        [SerializeField] private Button _btnBuild;
        [SerializeField] private ScrollRect _srBuildCatalogue;

        private MainUIPanelEventHolder _eventHolder = new MainUIPanelEventHolder();

        protected override IUIPanelBaseEventInvoker GetBaseEventInvoker() { return _eventHolder; }
    }
}