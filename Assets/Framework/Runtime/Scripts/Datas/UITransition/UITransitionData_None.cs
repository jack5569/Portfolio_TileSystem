using DG.Tweening;
using UnityEngine;

namespace J_Framework
{
    [CreateAssetMenu(menuName = "Data/UI Transition/Empty")]
    public partial class UITransitionData_None : UITransitionDataBase
    {
        [SerializeField] private bool _show;

        public override Tween GetTween(GameObject ui, TweenCallback onCompleted = null)
        {
            Tween tween = ui.transform.DOScale(_show ? 1.0f : 0.0f, 0.0f);
            return tween;
        }

        public override float GetDuration(GameObject ui)
        {
            return 0.0f;
        }
    }
}
