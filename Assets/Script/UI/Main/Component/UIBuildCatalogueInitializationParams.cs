using Game.GridSystem;

namespace Game.UI
{
    public class UIBuildCatalogueInitializationParams
    {
        public GridPlaceableFactory GridPlaceableFactory;
        public GameCamera GameCamera;
        public ICustomGridClient GridClient;

        public GridPlaceableDataCollection DataCollection;
    }
}