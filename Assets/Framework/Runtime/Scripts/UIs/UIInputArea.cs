using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace J_Framework
{
    public class UIInputArea : MonoBehaviour
    {
        public event Action<Vector2> OnTapExecuted;
        public event Action<Vector2> OnClickExecuted;
        public event Action<Vector2, Vector2> OnDragStarted;
        public event Action<Vector2, Vector2> OnDragOngoing;
        public event Action<Vector2, Vector2> OnDragEnded;
        public event Action<Vector2> OnHoldStarted;
        public event Action<Vector2> OnHoldOngoing;
        public event Action<Vector2> OnHoldEnded;
        public event Action<Vector2> OnSwipeExecuted;
        public event Action<float> OnSpreadExecuted;

        [Header("Settings")]
        [SerializeField] private PointerGesture _supportedPointerGestures;

        [Header("Click settings")]
        [ShowIf(nameof(_isClickGestureSupported))]
        [SerializeField] private float _clickDragDeadZone = 10.0f;

        [Header("Drag settings")]
        [ShowIf(nameof(_isDragGestureSupported))]
        [SerializeField] private float _dragThreshold = 10.0f;

        [Header("Hold settings")]
        [ShowIf(nameof(_isHoldGestureSupported))]
        [SerializeField] private float _holdThreshold = 1.0f;
        [ShowIf(nameof(_isHoldGestureSupported))]
        [SerializeField] private float _holdDragDeadZone = 10.0f;

        [Header("Swipe settings")]
        [ShowIf(nameof(_isSwipeGestureSupported))]
        [SerializeField] private float _swipeThreshold = 30.0f;
        [ShowIf(nameof(_isSwipeGestureSupported))]
        [SerializeField] private float _swipeInputWindow = 0.5f;

        [Header("Spread settings")]
        [ShowIf(nameof(_isSpreadGestureSupported))]
        [SerializeField] private float _spreadThreshold = 30.0f;

        [Header("References")]
        [SerializeField] private EventTrigger _eventTrigger;

        // Supported gesture properties
        private bool _isTapGestureSupported => (_supportedPointerGestures & PointerGesture.Tap) != 0;
        private bool _isClickGestureSupported => (_supportedPointerGestures & PointerGesture.Click) != 0;
        private bool _isDragGestureSupported => (_supportedPointerGestures & PointerGesture.Drag) != 0;
        private bool _isHoldGestureSupported => (_supportedPointerGestures & PointerGesture.Hold) != 0;
        private bool _isSwipeGestureSupported => (_supportedPointerGestures & PointerGesture.Swipe) != 0;
        private bool _isSpreadGestureSupported => (_supportedPointerGestures & PointerGesture.Spread) != 0;

        // Event trigger entry list
        private List<EventTrigger.Entry> _listEventTriggerEntries = new List<EventTrigger.Entry>();

        private IEnumerable<ISinglePointerGesture> _singlePointerGestures;
        private IEnumerable<IDoublePointerGesture> _doublePointerGestures;
        private PointerInputHandler _inputHandler;

        #region MonoBehaviour

        private void Awake()
        {
            _listEventTriggerEntries.Add(EventTriggerEntryUtils.CreateEventTriggerEntry(EventTriggerType.PointerDown, OnPointerDownHandler));
            _listEventTriggerEntries.Add(EventTriggerEntryUtils.CreateEventTriggerEntry(EventTriggerType.Drag, OnPointerDraggedHandler));
            _listEventTriggerEntries.Add(EventTriggerEntryUtils.CreateEventTriggerEntry(EventTriggerType.PointerUp, OnPointerUpHandler));
        }

        private void OnEnable()
        {
            _eventTrigger.triggers.AddRange(_listEventTriggerEntries);
        }

        private void OnDisable()
        {
            _eventTrigger.triggers.RemoveRange(0, _listEventTriggerEntries.Count);
        }

        private void Start()
        {
            // Single pointer gestures
            List<ISinglePointerGesture> listSinglePointerGesture = new List<ISinglePointerGesture>();
            if (_isTapGestureSupported)
                listSinglePointerGesture.Add(new SinglePointerGesture_Tap(OnTapExecutedHandler));
            if (_isClickGestureSupported)
                listSinglePointerGesture.Add(new SinglePointerGesture_Click(_clickDragDeadZone, OnClickExecutedHandler));
            if (_isDragGestureSupported)
                listSinglePointerGesture.Add(new SinglePointerGesture_Drag(_dragThreshold, OnDragBeganHandler, OnDragOngoingHandler, OnDragEndedHandler));
            if (_isSwipeGestureSupported)
                listSinglePointerGesture.Add(new SinglePointerGesture_Swipe(_swipeThreshold, _swipeInputWindow, OnSwipeExecutedHandler));
            if (_isHoldGestureSupported)
                listSinglePointerGesture.Add(new SinglePointerGesture_Hold(_holdThreshold, _holdDragDeadZone, OnHoldBeganHandler, OnHoldOngoingHandler, OnHoldEndedHandler));
            _singlePointerGestures = listSinglePointerGesture;

            // Double pointer gestures
            List<IDoublePointerGesture> listDoublePointerGesture = new List<IDoublePointerGesture>();
            if (_isSpreadGestureSupported)
                listDoublePointerGesture.Add(new DoublePointerGesture_Spread(_spreadThreshold, OnSpreadExecutedHandler));
            _doublePointerGestures = listDoublePointerGesture;

            // Pointer input handler
            _inputHandler = new PointerInputHandler(_singlePointerGestures, _doublePointerGestures);
        }

        private void Update()
        {
            if (_inputHandler != null)
                _inputHandler.Update(Time.deltaTime);
        }

        #endregion

        #region Event trigger entries' callbacks

        private void OnPointerDownHandler(BaseEventData eventData)
        {
            PointerEventData pointerEventData = (PointerEventData)eventData;
            if (pointerEventData != null)
                _inputHandler.HandlePointerDown(pointerEventData);
        }

        private void OnPointerDraggedHandler(BaseEventData eventData)
        {
            PointerEventData pointerEventData = (PointerEventData)eventData;
            if (pointerEventData != null)
                _inputHandler.HandlePointerMove(pointerEventData);
        }

        private void OnPointerUpHandler(BaseEventData eventData)
        {
            PointerEventData pointerEventData = (PointerEventData)eventData;
            if (pointerEventData != null)
                _inputHandler.HandlePointerUp(pointerEventData);
        }

        #endregion

        #region Events

        private void OnTapExecutedHandler(Vector2 position)
        {
            OnTapExecuted?.Invoke(position);
        }

        private void OnClickExecutedHandler(Vector2 position)
        {
            OnClickExecuted?.Invoke(position);
        }

        private void OnDragBeganHandler(Vector2 deltaPosition, Vector2 position)
        {
            OnDragStarted?.Invoke(deltaPosition, position);
        }

        private void OnDragOngoingHandler(Vector2 deltaPosition, Vector2 position)
        {
            OnDragOngoing?.Invoke(deltaPosition, position);
        }

        private void OnDragEndedHandler(Vector2 deltaPosition, Vector2 position)
        {
            OnDragEnded?.Invoke(deltaPosition, position);
        }

        private void OnHoldBeganHandler(Vector2 position)
        {
            OnHoldStarted?.Invoke(position);
        }

        private void OnHoldOngoingHandler(Vector2 position)
        {
            OnHoldOngoing?.Invoke(position);
        }

        private void OnHoldEndedHandler(Vector2 position)
        {
            OnHoldEnded?.Invoke(position);
        }

        private void OnSwipeExecutedHandler(Vector2 direction)
        {
            OnSwipeExecuted?.Invoke(direction);
        }

        private void OnSpreadExecutedHandler(float deltaPositionMagnitude)
        {
            OnSpreadExecuted?.Invoke(deltaPositionMagnitude);
        }

        #endregion
    }
}