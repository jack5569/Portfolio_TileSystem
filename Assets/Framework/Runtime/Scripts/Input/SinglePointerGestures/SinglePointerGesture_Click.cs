using System;
using UnityEngine;

namespace J_Framework
{
    public class SinglePointerGesture_Click : SinglePointerGestureBase
    {
        private Action<Vector2> _onExecuted;

        private float _dragDeadzone;

        private bool _isExecuted;
        private bool _isDragDeadzoneExceeded;

        public SinglePointerGesture_Click(float dragDeadzone, Action<Vector2> onExecuted)
        {
            _dragDeadzone = dragDeadzone;
            _onExecuted = onExecuted;
        }

        public override void UpdateState(int pointerId, CustomPointerPhase phase, Vector2 position)
        {
            base.UpdateState(pointerId, phase, position);

            if (!IsActivePointer(pointerId))
                return;

            if (phase == CustomPointerPhase.OnScreen)
            {
                if (!_isDragDeadzoneExceeded)
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
                if (!_isExecuted && !_isDragDeadzoneExceeded)
                    OnExecutedHander(position);

                Reset();
            }
        }

        protected override void Reset()
        {
            base.Reset();
            _isExecuted = false;
            _isDragDeadzoneExceeded = false;
        }

        private void OnExecutedHander(Vector2 position)
        {
            _isExecuted = true;
            _onExecuted?.Invoke(position);
        }
    }
}