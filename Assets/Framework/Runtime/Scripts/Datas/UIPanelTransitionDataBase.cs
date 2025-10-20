using DG.Tweening;
using UnityEngine;

namespace J_Framework
{
    public abstract class UIPanelTransitionDataBase : ScriptableObject
    {
        [SerializeField] private float _duration;
        [SerializeField] private Ease _easingType;

        public float Duration { get { return _duration; } }
        public Ease EasingType { get { return _easingType; } }

        public abstract Tween GetTween(bool show, GameObject targetGameObject);
        public abstract void SwitchState(bool show, GameObject targetGameObject);

        protected virtual void InitializeTween(Tween tween)
        {
            // Pause the tween so it doesn't get played directly
            tween.Pause();
        }
    }
}