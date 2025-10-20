using DG.Tweening;
using UnityEngine;

namespace J_Framework
{
    [CreateAssetMenu(menuName = "Data/UI Panel Transition/Alpha")]
    public class UIPanelTransitionData_Alpha : UIPanelTransitionDataBase
    {
        public override Tween GetTween(bool show, GameObject targetGameObject)
        {
            CanvasGroup canvasGroup = targetGameObject.GetComponent<CanvasGroup>();

            Tween tween = canvasGroup.DOFade(show ? 1.0f : 0.0f, Duration);
            InitializeTween(tween);
            return tween;
        }

        public override void SwitchState(bool show, GameObject targetGameObject)
        {
            CanvasGroup canvasGroup = targetGameObject.GetComponent<CanvasGroup>();
            canvasGroup.alpha = show ? 1.0f : 0.0f;
        }
    }
}
