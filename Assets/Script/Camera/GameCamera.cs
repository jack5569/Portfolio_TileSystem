using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    #region Public methods

    public Vector2 ScreenToWorldPosition(Vector2 screenPosition) { return _camera.ScreenToWorldPoint(screenPosition); }

    #endregion
}
