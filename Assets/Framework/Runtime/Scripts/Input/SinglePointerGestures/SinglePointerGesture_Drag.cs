using System;
using UnityEngine;

namespace J_Framework
{
    public class SinglePointerGesture_Drag : SinglePointerGestureBase
    {
        private Action<Vector2, Vector2> _onStarted;
        private Action<Vector2, Vector2> _onOngoing;
        private Action<Vector2, Vector2> _onEnded;

        private bool _isThresholdExceeded;
        private float _threshold;

        public SinglePointerGesture_Drag(float threshold, Action<Vector2, Vector2> onStarted, Action<Vector2, Vector2> onOngoing, Action<Vector2, Vector2> onEnded)
        {
            _threshold = threshold;
            _onStarted = onStarted;
            _onOngoing = onOngoing;
            _onEnded = onEnded;
        }

        #region Public methods

        public override void UpdateState(int pointerId, CustomPointerPhase phase, Vector2 position)
        {
            base.UpdateState(pointerId, phase, position);

            if (!IsActivePointer(pointerId))
                return;

            if (phase == CustomPointerPhase.OnScreen)
            {
                if (!_isThresholdExceeded)
                {
                    if ((ActivePointer.CurrentPosition - ActivePointer.StartPosition).magnitude > _threshold)
                        OnStartedHandler(ActivePointer.CurrentPosition - ActivePointer.StartPosition, ActivePointer.CurrentPosition);
                }
                else
                {
                    OnOngoingHandler(ActivePointer.CurrentPosition - ActivePointer.PreviousPosition, ActivePointer.CurrentPosition);
                }
            }
            else
            {
                if (_isThresholdExceeded)
                    OnEndedHandler(ActivePointer.CurrentPosition - ActivePointer.PreviousPosition, ActivePointer.CurrentPosition);

                Reset();
            }
        }

        #endregion

        #region Protected methods

        protected override void Reset()
        {
            base.Reset();
            _isThresholdExceeded = false;
        }

        #endregion

        #region Private methods

        private void OnStartedHandler(Vector2 deltaPosition, Vector2 position)
        {
            _isThresholdExceeded = true;
            _onStarted?.Invoke(deltaPosition, position);
        }

        private void OnOngoingHandler(Vector2 deltaPosition, Vector2 position)
        {
            _onOngoing?.Invoke(deltaPosition, position);
        }

        private void OnEndedHandler(Vector2 deltaPosition, Vector2 position)
        {
            _onEnded?.Invoke(deltaPosition, position);
        }

        #endregion
    }
}