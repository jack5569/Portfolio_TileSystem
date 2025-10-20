using System;
using UnityEngine;

namespace J_Framework
{
    public class SinglePointerGesture_Tap : SinglePointerGestureBase
    {
        private Action<Vector2> _onExecuted;

        private bool _isExecuted;

        public SinglePointerGesture_Tap(Action<Vector2> onExecuted)
        {
            _onExecuted = onExecuted;
        }

        public override void Initialize(int pointerId, Vector2 position)
        {
            base.Initialize(pointerId, position);
            _isExecuted = false;
        }

        public override void UpdateState(int pointerId, CustomPointerPhase phase, Vector2 position)
        {
            base.UpdateState(pointerId, phase, position);

            if (!IsActivePointer(pointerId))
                return;

            if (phase == CustomPointerPhase.OnScreen)
            {
                if (!_isExecuted)
                    OnExecutedHander(position);
            }
            else
            {
                Reset();
            }
        }

        private void OnExecutedHander(Vector2 position)
        {
            _isExecuted = true;
            _onExecuted?.Invoke(position);
        }
    }
}