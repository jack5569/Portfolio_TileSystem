using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace J_Framework
{
    public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        public UnityEvent OnClicked => _onClicked;

        [Header("Settings")]
        [SerializeField] private bool _interactable = true;
        [SerializeField] private UnityEvent _onClicked;

        [Header("Transition")]
        [SerializeField] private UITransitionPlayer _transitionPlayer;
        [SerializeField] private CompositeUITransitionData _transitionDataNormal;
        [SerializeField] private CompositeUITransitionData _transitionDataHighlighted;
        [SerializeField] private CompositeUITransitionData _transitionDataPressed;
        [SerializeField] private CompositeUITransitionData _transitionDataSelected;
        [SerializeField] private CompositeUITransitionData _transitionDataDisabled;

        public bool Interactable
        {
            get { return GetResolvedInteractable(); }
            set { _interactable = value; }
        }

        private RectTransform _rectTransform;
        private CanvasGroup[] _parentCanvasGroups;

        private UIButtonState _currentState;

        #region MonoBehaviour

        private void Awake()
        {
            _rectTransform = transform as RectTransform;
        }

        private void Start()
        {
            // Refresh parent canvas groups
            _parentCanvasGroups = GetComponentsInParent<CanvasGroup>();
        }

        private void OnTransformParentChanged()
        {
            // Refresh parent canvas groups
            _parentCanvasGroups = GetComponentsInParent<CanvasGroup>();
        }

        private void Update()
        {
            // Canvas group interactable change detection
            if (_currentState == UIButtonState.Disabled)
            {
                if (GetResolvedInteractable())
                    SwitchState(UIButtonState.Normal);
            }
            else
            {
                if (!GetResolvedInteractable())
                    SwitchState(UIButtonState.Disabled);
            }
        }

        #endregion

        #region Private methods

        private void SwitchState(UIButtonState state)
        {
            // Return if same state
            if (_currentState == state)
                return;

            // Updates state and kill any available tween
            _currentState = state;
            _transitionPlayer.Kill();

            // Transition
            if (_transitionDataNormal)
            {
                switch (_currentState)
                {
                    case UIButtonState.Normal:
                        _transitionPlayer.Play(_transitionDataNormal);
                        break;
                    case UIButtonState.Highlighted:
                        _transitionPlayer.Play(_transitionDataHighlighted);
                        break;
                    case UIButtonState.Pressed:
                        _transitionPlayer.Play(_transitionDataPressed);
                        break;
                    case UIButtonState.Selected:
                        _transitionPlayer.Play(_transitionDataSelected);
                        break;
                    case UIButtonState.Disabled:
                        _transitionPlayer.Play(_transitionDataDisabled);
                        break;
                    default:
                        Debug.LogError($"UIButtonState of {state} for {nameof(SwitchState)} is not implemented!");
                        break;
                }
            }
        }

        private Rect GetWorldRect()
        {
            Vector2 pivot = _rectTransform.pivot;
            Vector2 size = _rectTransform.rect.size;
            float minPointX = _rectTransform.position.x - pivot.x * size.x;
            float minPointY = _rectTransform.position.y - pivot.x * size.y;
            float maxPointX = _rectTransform.position.x + (1.0f - pivot.x) * size.x;
            float maxPointY = _rectTransform.position.x + (1.0f - pivot.y) * size.y;
            return new Rect()
            {
                min = new Vector2(minPointX, minPointY),
                max = new Vector2(maxPointX, maxPointY)
            };
        }

        private bool GetResolvedInteractable()
        {
            bool canvasGroupInteractable = true;
            foreach (CanvasGroup canvasGroup in _parentCanvasGroups)
            {
                if (!canvasGroup.interactable)
                {
                    canvasGroupInteractable = false;
                    break;
                }
            }

            return canvasGroupInteractable && _interactable;
        }

        #endregion

        #region Pointer interfaces

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            // Return if not interactable
            if (!GetResolvedInteractable())
                return;

            // Return if in pressed state
            if (_currentState == UIButtonState.Pressed)
                return;

            SwitchState(UIButtonState.Highlighted);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            // Return if not interactable
            if (!GetResolvedInteractable())
                return;

            // Return if in pressed state
            if (_currentState == UIButtonState.Pressed)
                return;

            SwitchState(UIButtonState.Normal);
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            // Return if not interactable
            if (!GetResolvedInteractable())
                return;

            EventSystem.current.SetSelectedGameObject(gameObject);
            SwitchState(UIButtonState.Pressed);
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            // Return if not interactable
            if (!GetResolvedInteractable())
                return;

            // If release outside of the button, back to normal state
            // Else transit to highlighted
            if (!GetWorldRect().Contains(eventData.position))
                SwitchState(UIButtonState.Normal);
            else
                SwitchState(UIButtonState.Highlighted);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            // Return if not interactable
            if (!GetResolvedInteractable())
                return;

            // Event
            OnClicked.Invoke();
        }

        #endregion
    }
}
