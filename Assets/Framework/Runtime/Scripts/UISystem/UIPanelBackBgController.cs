using NaughtyAttributes;
using UnityEngine;

namespace J_Framework.UI
{
    public partial class UIPanelBackBgController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private UITransitionPlayer _transitionPlayer;

        [Header("Datas")]
        [SerializeField] private UITransitionDataBase _showData;
        [SerializeField] private UITransitionDataBase _hideData;

        public void Show()
        {
            _transitionPlayer.Play(_showData);
        }

        public void Hide()
        {
            _transitionPlayer.Play(_hideData);
        }
    }
}
