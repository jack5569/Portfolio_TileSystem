using System;
using UnityEngine;

namespace J_Framework
{
    public class SinglePointerGesture_Hold : SinglePointerGestureBase
    {
        private Action<Vector2> _onStarted;
        private Action<Vector2> _onOngoing;
        private Action<Vector2> _onEnded;

        private float _threshold;
        private float _dragDeadzone;

        private bool _isThresholdExceeded;
        private bool _isDragDeadzoneExceeded;
        private float _elapsedTime;

        public SinglePointerGesture_Hold(float threshold, float dragDeadzone, Action<Vector2> onStarted, Action<Vector2> onOngoing, Action<Vector2> onEnded)
        {
            _threshold = threshold;
            _dragDeadzone = dragDeadzone;
            _onStarted = onStarted;
            _onOngoing = onOngoing;
            _onEnded = onEnded;
        }

        #region Public methods

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (ActivePointer == null)
                return;

            if (ActivePointer.Phase == CustomPointerPhase.OnScreen)
            {
                _elapsedTime += deltaTime;
                if (!_isThresholdExceeded)
                {
                    if (!_isDragDeadzoneExceeded)
                    {
                        if (_elapsedTime > _threshold)
                            OnStartedHandler(ActivePointer.CurrentPosition);
                    }
                }
                else
                {
                    OnOngoingHandler(ActivePointer.CurrentPosition);
                }
            }
        }

        public override void UpdateState(int pointerId, CustomPointerPhase phase, Vector2 position)
        {
            base.UpdateState(pointerId, phase, position);

            if (!IsActivePointer(pointerId))
                return;

            if (phase == CustomPointerPhase.OnScreen)
            {
                if (!_isThresholdExceeded && !_isDragDeadzoneExceeded)
                {
                    if ((ActivePointer.CurrentPosition - ActivePointer.StartPosition).magnitude > _dragDeadzone)
                    {
                        _isDragDeadzoneExceeded = true;
                        return;
                    }
                }
            }
            else
            {
                if (_isThresholdExceeded)
                    OnEndedHandler(ActivePointer.CurrentPosition);

                Reset();
            }
        }

        #endregion

        #region Protected methods

        protected override void Reset()
        {
            base.Reset();
            _isThresholdExceeded = false;
            _isDragDeadzoneExceeded = false;
            _elapsedTime = 0.0f;
        }

        #endregion

        #region Events

        private void OnStartedHandler(Vector2 position)
        {
            _isThresholdExceeded = true;
            _onStarted?.Invoke(position);
        }

        private void OnOngoingHandler(Vector2 position)
        {
            _onOngoing?.Invoke(position);
        }

        private void OnEndedHandler(Vector2 position)
        {
            _onEnded?.Invoke(position);
        }

        #endregion
    }
}