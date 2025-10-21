using UnityEngine;
using J_Framework.UI;

namespace Game.UI
{
    public class UIPanel_Main : UIPanelBase
    {
        [Header("References")]
        [SerializeField] private UIBuildCatalogue _buildCatalogue;

        private MainUIPanelEventHolder _eventHolder = new MainUIPanelEventHolder();

        protected override IUIPanelBaseEventInvoker GetBaseEventInvoker() { return _eventHolder; }

        #region Public methods

        public void Initialize(MainPanelInitializationParams initializationParams)
        {
            _buildCatalogue.Initialize(new UIBuildCatalogueInitializationParams()
            {
                GridPlaceableFactory = initializationParams.GridPlaceableFactory,
                GameCamera = initializationParams.GameCamera,
                GridClient = initializationParams.GridClient,

                DataCollection = initializationParams.DataCollection
            });
        }

        #endregion
    }
}