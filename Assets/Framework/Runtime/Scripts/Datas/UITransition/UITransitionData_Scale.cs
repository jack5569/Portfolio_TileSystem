using DG.Tweening;
using UnityEngine;

namespace J_Framework
{
    [CreateAssetMenu(menuName = "Data/UI Transition/Scale")]
    public partial class UITransitionData_Scale : UITransitionDataBase
    {
        [SerializeField] private float _scalingSpeedPerSecond;
        [SerializeField] private float _targetScale;
        [SerializeField] private Ease _ease;

        public override Tween GetTween(GameObject ui, TweenCallback onCompleted = null)
        {
            RectTransform rectTransform = (RectTransform)ui.transform;
            Tween tween = rectTransform.DOScale(_targetScale, GetDuration(ui));
            tween.OnComplete(onCompleted);
            tween.SetEase(_ease);
            tween.Goto(0.0f);
            return tween;
        }

        public override float GetDuration(GameObject ui)
        {
            RectTransform rectTransform = (RectTransform)ui.transform;
            float deltaScale = Mathf.Abs(_targetScale - Mathf.Max(rectTransform.localScale.x, rectTransform.localScale.y));
            return deltaScale / _scalingSpeedPerSecond;
        }
    }
}
