using UnityEngine;

namespace J_Framework
{
    [RequireComponent(typeof(RectTransform))]
    public class UISafeAreaFitter : MonoBehaviour
    {
        [SerializeField] private bool _fitHorizontal = true;
        [SerializeField] private bool _fitVertical = true;

        private RectTransform _rectTransform;
        private Vector2 _canvasSizeDelta;

        #region MonoBehaviour

        private void Awake()
        {
            // Self component setup
            _rectTransform = (RectTransform)transform;

            // Parent canvas size getter
            Canvas canvas = GetComponentInParent<Canvas>();
            _canvasSizeDelta = ((RectTransform)canvas.transform).sizeDelta;
        }

        private void Start()
        {
            Rect rectSafeArea = Screen.safeArea;

            // Anchor calculation
            Vector2 anchorMin = _rectTransform.anchorMin;
            Vector2 anchorMax = _rectTransform.anchorMax;
            if (_fitHorizontal)
            {
                anchorMin.x = rectSafeArea.xMin / _canvasSizeDelta.x;
                anchorMax.x = rectSafeArea.xMax / _canvasSizeDelta.x;
            }
            if (_fitVertical)
            {
                anchorMin.y = rectSafeArea.yMin / _canvasSizeDelta.y;
                anchorMax.y = rectSafeArea.yMax / _canvasSizeDelta.y;
            }

            // Apply
            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
            _rectTransform.offsetMin = Vector2.zero;
            _rectTransform.offsetMax = Vector2.zero;
        }

        #endregion
    }
}