using Game.GridSystem;

namespace Game.UI
{
    public class UIBuildItemInitializationParams
    {
        public GridPlaceableFactory GridPlaceableFactory;
        public GameCamera GameCamera;
        public ICustomGridClient GridClient;

        public GridPlaceableData Data;
    }
}