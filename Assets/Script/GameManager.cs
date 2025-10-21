using Game.GridSystem;
using Game.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GridSystem _gridSystem;
    [SerializeField] private GameCamera _gameCamera;
    [SerializeField] private GridPlaceableFactory _gridPlaceableFactory;

    [Header("Datas")]
    [SerializeField] private GridPlaceableDataCollection _gridPlaceableDataCollection;
    [SerializeField] private GridData _gridDataToLoad;

    #region MonoBehaviour

    private void Start()
    {
        Initialize();
        StartGame();
    }

    #endregion

    #region Public methods


    #endregion

    #region Private methods

    private void Initialize()
    {
        _gridPlaceableFactory.Initialize(_gridSystem.GridClient);

        // UI
        UISystem.Instance.Panel.Get<UIPanel_Main>().Initialize(new MainPanelInitializationParams()
        {
            GridPlaceableFactory = _gridPlaceableFactory,
            GameCamera = _gameCamera,
            GridClient = _gridSystem.GridClient,

            DataCollection = _gridPlaceableDataCollection
        });
    }

    private void StartGame()
    {
        _gridSystem.Load(_gridDataToLoad);

        // UI
        UISystem.Instance.Panel.Get<UIPanel_Main>().Show();
    }

    #endregion
}
