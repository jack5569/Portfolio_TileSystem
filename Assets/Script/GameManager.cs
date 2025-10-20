using Game.GridSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GridSystem _gridSystem;

    [Header("Datas")]
    [SerializeField] private GridPlaceableDataCollection _gridPlaceableDataCollection;
    [SerializeField] private GridData _gridDataToLoad;
}
