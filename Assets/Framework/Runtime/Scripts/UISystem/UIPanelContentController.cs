using DG.Tweening;
using UnityEngine;

namespace J_Framework.UI
{
    public partial class UIPanelContentController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private UITransitionPlayer _transitionPlayer;

        [Header("Datas")]
        [SerializeField] private UITransitionDataBase _showData;
        [SerializeField] private UITransitionDataBase _hideData;

        public void Show(TweenCallback onCompleted = null)
        {
            _transitionPlayer.Play(_showData, onCompleted);
        }

        public void Hide(TweenCallback onCompleted = null)
        {
            _transitionPlayer.Play(_hideData, onCompleted);
        }
    }
}
