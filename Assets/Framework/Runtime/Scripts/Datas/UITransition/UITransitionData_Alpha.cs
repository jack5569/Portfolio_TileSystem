using DG.Tweening;
using UnityEngine;

namespace J_Framework
{
    [CreateAssetMenu(menuName = "Data/UI Transition/Alpha")]
    public partial class UITransitionData_Alpha : UITransitionDataBase
    {
        [SerializeField] private float _fadingSpeedPerSecond;
        [SerializeField] private float _targetAlpha;
        [SerializeField] private Ease _ease;

        public override Tween GetTween(GameObject ui, TweenCallback onCompleted = null)
        {
            CanvasGroup canvasGroup = ui.GetComponent<CanvasGroup>();
            Tween tween = canvasGroup.DOFade(_targetAlpha, GetDuration(ui));
            tween.OnComplete(onCompleted);
            tween.SetEase(_ease);
            tween.Goto(0.0f);
            return tween;
        }

        public override float GetDuration(GameObject ui)
        {
            CanvasGroup canvasGroup = ui.GetComponent<CanvasGroup>();
            float deltaAlpha = Mathf.Abs(_targetAlpha - canvasGroup.alpha);
            return deltaAlpha / _fadingSpeedPerSecond;
        }
    }
}
