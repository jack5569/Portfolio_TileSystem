using System;
using UnityEngine;

namespace J_Framework
{
    public class SinglePointerGesture_Swipe : SinglePointerGestureBase
    {
        private Action<Vector2> _onExecuted;

        private bool _isThresholdExceeded;
        private float _timeInitialization;
        private float _threshold;
        private float _inputWindow;

        public SinglePointerGesture_Swipe(float threshold, float inputWindow, Action<Vector2> onExecuted)
        {
            _threshold = threshold;
            _inputWindow = inputWindow;
            _onExecuted = onExecuted;
        }

        public override void Initialize(int pointerId, Vector2 position)
        {
            base.Initialize(pointerId, position);
            _isThresholdExceeded = false;
            _timeInitialization = Time.time;
        }

        public override void UpdateState(int pointerId, CustomPointerPhase phase, Vector2 position)
        {
            base.UpdateState(pointerId, phase, position);

            if (!IsActivePointer(pointerId))
                return;

            if (phase == CustomPointerPhase.OnScreen)
            {
                if (!_isThresholdExceeded)
                    _isThresholdExceeded = (ActivePointer.CurrentPosition - ActivePointer.StartPosition).magnitude >= _threshold;
            }
            else
            {
                if (_isThresholdExceeded && Time.time < _timeInitialization + _inputWindow)
                {
                    Vector2 direction = (ActivePointer.CurrentPosition - ActivePointer.StartPosition).normalized;
                    _onExecuted?.Invoke(direction);
                }
                
                Reset();
            }
        }

        protected override void Reset()
        {
            base.Reset();
            _isThresholdExceeded = false;
            _timeInitialization = 0.0f;
        }
    }
}
