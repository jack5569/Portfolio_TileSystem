using Game.GridSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIBuildCatalogue : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private UIBuildItem _uiBuildItemPrefab;

        #region Public methods

        public void Initialize(UIBuildCatalogueInitializationParams initializationParams)
        {
            foreach (GridPlaceableData data in initializationParams.DataCollection.GetAll())
            {
                UIBuildItem instance = Instantiate(_uiBuildItemPrefab, _scrollRect.content.transform, false);
                instance.Initialize(new UIBuildItemInitializationParams()
                {
                    GridPlaceableFactory = initializationParams.GridPlaceableFactory,
                    GameCamera = initializationParams.GameCamera,
                    GridClient = initializationParams.GridClient,

                    Data = data
                });
            }
        }

        #endregion
    }
}