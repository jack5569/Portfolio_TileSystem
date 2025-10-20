using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace J_Framework
{
    public class PointerInputHandler
    {
        private const int SUPPORTED_FINGER_COUNT = 2;

        private List<int> _listActivePointerId = new List<int>();
        private IEnumerable<ISinglePointerGesture> _singlePointerGestures;
        private IEnumerable<IDoublePointerGesture> _doublePointerGestures;

        public PointerInputHandler(IEnumerable<ISinglePointerGesture> singlePointerGestures, IEnumerable<IDoublePointerGesture> doublePointerGestures)
        {
            _singlePointerGestures = singlePointerGestures;
            _doublePointerGestures = doublePointerGestures;
        }

        public void Update(float deltaTime)
        {
            // Only process single pointer gesture if only have one active pointer
            if (_listActivePointerId.Count == 1)
            {
                // Single pointer gesture handling
                foreach (ISinglePointerGesture gesture in _singlePointerGestures)
                    gesture.Update(deltaTime);
            }

            // Double pointer gesture handling
            foreach (IDoublePointerGesture gesture in _doublePointerGestures)
                gesture.Update(deltaTime);
        }

        public void HandlePointerDown(PointerEventData eventData)
        {
            // Return if cannot accept new input
            if (!CanAcceptNewPointer())
                return;

            _listActivePointerId.Add(eventData.pointerId);

            // Only process single pointer gesture if only have one active pointer
            if (_listActivePointerId.Count == 1)
            {
                // Single pointer gesture handling
                foreach (ISinglePointerGesture gesture in _singlePointerGestures)
                {
                    gesture.Initialize(eventData.pointerId, eventData.position);
                    gesture.UpdateState(eventData.pointerId, CustomPointerPhase.OnScreen, eventData.position);
                }
            }

            // Double pointer gesture handling
            foreach (IDoublePointerGesture gesture in _doublePointerGestures)
            {
                gesture.Initialize(eventData.pointerId, eventData.position);
                gesture.UpdateState(eventData.pointerId, CustomPointerPhase.OnScreen, eventData.position);
            }
        }

        public void HandlePointerMove(PointerEventData eventData)
        {
            // Return if is not one of active pointer
            if (!_listActivePointerId.Contains(eventData.pointerId))
                return;

            // Only process single pointer gesture if only have one active pointer
            if (_listActivePointerId.Count == 1)
            {
                foreach (ISinglePointerGesture gesture in _singlePointerGestures)
                    gesture.UpdateState(eventData.pointerId, CustomPointerPhase.OnScreen, eventData.position);
            }

            // Double pointer gesture handling
            foreach (IDoublePointerGesture gesture in _doublePointerGestures)
                gesture.UpdateState(eventData.pointerId, CustomPointerPhase.OnScreen, eventData.position);
        }

        public void HandlePointerUp(PointerEventData eventData)
        {
            // Return if is not one of active pointer
            if (!_listActivePointerId.Contains(eventData.pointerId))
                return;

            // Only process single pointer gesture if only have one active pointer
            if (_listActivePointerId.Count == 1)
            {
                foreach (ISinglePointerGesture gesture in _singlePointerGestures)
                    gesture.UpdateState(eventData.pointerId, CustomPointerPhase.OffScreen, eventData.position);
            }

            // Double pointer gesture handling
            foreach (IDoublePointerGesture gesture in _doublePointerGestures)
                gesture.UpdateState(eventData.pointerId, CustomPointerPhase.OffScreen, eventData.position);

            _listActivePointerId.Remove(eventData.pointerId);
        }

        #region Private methods

        private bool CanAcceptNewPointer() { return _listActivePointerId.Count < SUPPORTED_FINGER_COUNT; }

        #endregion
    }
}