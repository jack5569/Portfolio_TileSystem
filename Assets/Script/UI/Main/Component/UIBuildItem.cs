using Game.GridSystem;
using J_Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIBuildItem : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Image _imgVisual;
        [SerializeField] private UIInputArea _inputArea;

        private GridPlaceableFactory _gridPlaceableFactory;
        private GameCamera _gameCamera;
        private ICustomGridClient _gridClient;

        private GridPlaceableData _data;
        
        private GridPlaceable _instance;

        #region MonoBehaviour

        private void OnEnable()
        {
            _inputArea.OnDragStarted += OnDragStartedHandler;
            _inputArea.OnDragOngoing += OnDragOngoingHandler;
            _inputArea.OnDragEnded += OnDragEndedHandler;
        }

        private void OnDisable()
        {
            _inputArea.OnDragStarted -= OnDragStartedHandler;
            _inputArea.OnDragOngoing -= OnDragOngoingHandler;
            _inputArea.OnDragEnded -= OnDragEndedHandler;
        }

        #endregion

        #region Public methods

        public void Initialize(UIBuildItemInitializationParams initializationParams)
        {
            _gridPlaceableFactory = initializationParams.GridPlaceableFactory;
            _gameCamera = initializationParams.GameCamera;
            _gridClient = initializationParams.GridClient;

            _data = initializationParams.Data;
            _imgVisual.sprite = _data.Sprite;
        }

        #endregion

        #region Input area events

        private void OnDragStartedHandler(Vector2 deltaPosition, Vector2 position)
        {
            _instance = _gridPlaceableFactory.Create(_data, _gameCamera.ScreenToWorldPosition(position));
            _imgVisual.enabled = false;
        }

        private void OnDragOngoingHandler(Vector2 deltaPosition, Vector2 position)
        {
            Vector2 worldPosition = _gameCamera.ScreenToWorldPosition(position);
            _instance.UpdatePosition(_gridClient.GetNearestCellFromWorldPosition(worldPosition));
            _gridClient.HandlePlaceableEditModePlaceablePositionUpdate(_instance);
        }

        private void OnDragEndedHandler(Vector2 deltaPosition, Vector2 position)
        {
            _imgVisual.enabled = true;
            _gridClient.HandlePlaceableEditModeConfirmPlaceablePosition(_instance);
            _instance = null;
        }

        #endregion
    }
}