using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace J_Framework
{
    [CreateAssetMenu(menuName = "Data/UI Transition/Tint")]
    public partial class UITransitionData_Tint : UITransitionDataBase
    {
        [Tooltip("Channel value per second")]
        [SerializeField] private float _speed;
        [SerializeField] private Color _baseColor = Color.white;
        [SerializeField] private Color _tintColor = Color.white;
        [SerializeField] private Ease _ease;

        private Color ResultTintColor => _baseColor * _tintColor;

        public override Tween GetTween(GameObject ui, TweenCallback onCompleted = null)
        {
            Image image = ui.GetComponent<Image>();
            Tween tween = image.DOColor(ResultTintColor, GetDuration(ui));
            tween.OnComplete(onCompleted);
            tween.SetEase(_ease);
            tween.Goto(0.0f);
            return tween;
        }

        public override float GetDuration(GameObject ui)
        {
            Image image = ui.GetComponent<Image>();
            float deltaR = Mathf.Abs((ResultTintColor - image.color).r);
            float deltaG = Mathf.Abs((ResultTintColor - image.color).g);
            float deltaB = Mathf.Abs((ResultTintColor - image.color).b);
            float deltaA = Mathf.Abs((ResultTintColor - image.color).a);
            float maxDelta = Mathf.Max(deltaR, deltaG, deltaB, deltaA);
            return maxDelta / _speed;
        }
    }
}
