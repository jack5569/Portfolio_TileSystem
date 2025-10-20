using DG.Tweening;
using UnityEngine;

namespace J_Framework
{
    [CreateAssetMenu(menuName = "Data/UI Panel Transition/Scale")]
    public class UIPanelTransitionData_Scale : UIPanelTransitionDataBase
    {
        public override Tween GetTween(bool show, GameObject targetGameObject)
        {
            Transform transform = targetGameObject.transform;

            Tween tween = transform.DOScale(show ? 1.0f : 0.0f, Duration);
            InitializeTween(tween);
            return tween;
        }

        public override void SwitchState(bool show, GameObject targetGameObject)
        {
            Transform transform = targetGameObject.transform;
            transform.localScale = show ? Vector3.one : Vector3.zero;
        }
    }
}
