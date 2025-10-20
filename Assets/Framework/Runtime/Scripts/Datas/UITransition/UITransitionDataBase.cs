using DG.Tweening;
using UnityEngine;

namespace J_Framework
{
    public abstract partial class UITransitionDataBase : ScriptableObject
    {
        public abstract Tween GetTween(GameObject ui, TweenCallback onCompleted = null);
        public abstract float GetDuration(GameObject ui);
    }
}
