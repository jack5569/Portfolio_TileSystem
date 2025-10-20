using System;
using UnityEngine;

namespace J_Framework
{
    public class DoublePointerGesture_Spread : DoublePointerGestureBase
    {
        private Action<float> _onExecuted;

        private float _threshold;

        private bool _isThresholdExceeded;

        public DoublePointerGesture_Spread(float threshold, Action<float> onExecuted)
        {
            _threshold = threshold;
            _onExecuted = onExecuted;
        }

        #region Public methods

        public override void UpdateState(int pointerId, CustomPointerPhase phase, Vector2 pointerPosition)
        {
            base.UpdateState(pointerId, phase, pointerPosition);

            if (HasFirstActivePointer() && HasSecondActivePointer())
            {
                if (FirstActivePointer.Phase == CustomPointerPhase.OnScreen && SecondActivePointer.Phase == CustomPointerPhase.OnScreen)
                {
                    if (!_isThresholdExceeded)
                    {
                        float currentDeltaPositionMagnitude = (FirstActivePointer.CurrentPosition - SecondActivePointer.CurrentPosition).magnitude;
                        float startDeltaPositionMagnitude = (FirstActivePointer.StartPosition - SecondActivePointer.StartPosition).magnitude;
                        float resultDeltaPositionMagnitude = currentDeltaPositionMagnitude - startDeltaPositionMagnitude;
                        if (Mathf.Abs(resultDeltaPositionMagnitude) > _threshold)
                        {
                            _isThresholdExceeded = true;

                            // Take the exceeded magnitude amount for the event
                            OnExecutedHandler(resultDeltaPositionMagnitude % _threshold);
                        }
                    }
                    else
                    {
                        float currentDeltaPositionMagnitude = (FirstActivePointer.CurrentPosition - SecondActivePointer.CurrentPosition).magnitude;
                        float previousDeltaPositionMagnitude = (FirstActivePointer.PreviousPosition - SecondActivePointer.PreviousPosition).magnitude;
                        float resultDeltaPositionMagnitude = currentDeltaPositionMagnitude - previousDeltaPositionMagnitude;
                        OnExecutedHandler(resultDeltaPositionMagnitude);
                    }
                }
                else
                {
                    if (FirstActivePointer.Phase == CustomPointerPhase.OffScreen)
                        ResetFirstActivePointer();

                    if (SecondActivePointer.Phase == CustomPointerPhase.OffScreen)
                        ResetSecondActivePointer();
                }
            }
            else
            {
                if (HasFirstActivePointer())
                {
                    if (FirstActivePointer.Phase == CustomPointerPhase.OffScreen)
                        ResetFirstActivePointer();
                }

                if (HasSecondActivePointer())
                {
                    if (SecondActivePointer.Phase == CustomPointerPhase.OffScreen)
                        ResetSecondActivePointer();
                }
            }
        }

        #endregion

        #region Protected methods

        protected override void Reset()
        {
            base.Reset();
            _isThresholdExceeded = false;
        }

        protected override void ResetFirstActivePointer()
        {
            base.ResetFirstActivePointer();
            _isThresholdExceeded = false;
        }

        protected override void ResetSecondActivePointer()
        {
            base.ResetSecondActivePointer();
            _isThresholdExceeded = false;
        }

        #endregion

        #region Events

        private void OnExecutedHandler(float deltaPositionMagnitude)
        {
            _onExecuted?.Invoke(deltaPositionMagnitude);
        }

        #endregion
    }
}