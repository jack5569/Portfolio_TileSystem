using UnityEngine;

namespace J_Framework
{
    public abstract class DoublePointerGestureBase : IDoublePointerGesture
    {
        private PointerInfo _firstActivePointer;
        private PointerInfo _secondActivePointer;

        protected PointerInfo FirstActivePointer => _firstActivePointer;
        protected PointerInfo SecondActivePointer => _secondActivePointer;

        #region Public methods

        public virtual void Initialize(int pointerId, Vector2 position)
        {
            if (!HasFirstActivePointer())
                _firstActivePointer = new PointerInfo(pointerId, position);
            else if (!HasSecondActivePointer())
                _secondActivePointer = new PointerInfo(pointerId, position);
        }

        public virtual void Update(float deltaTime)
        {
        }

        public virtual void UpdateState(int pointerId, CustomPointerPhase phase, Vector2 pointerPosition)
        {
            if (!IsActivePointer(pointerId))
                return;

            if (IsFirstActivePointer(pointerId))
                _firstActivePointer.Update(phase, pointerPosition);
            else if (IsSecondActivePointer(pointerId))
                _secondActivePointer.Update(phase, pointerPosition);
        }

        #endregion

        #region Protected methods

        protected bool IsActivePointer(int pointerId)
        {
            if (_firstActivePointer != null)
            {
                if (_firstActivePointer.PointerId == pointerId)
                    return true;
            }

            if (_secondActivePointer != null)
            {
                if (_secondActivePointer.PointerId == pointerId)
                    return true;
            }

            return false;
        }

        protected bool HasFirstActivePointer() { return _firstActivePointer != null; }
        protected bool IsFirstActivePointer(int pointerId)
        {
            if (_firstActivePointer != null)
                return _firstActivePointer.PointerId == pointerId;

            return false;
        }

        protected bool HasSecondActivePointer() { return _secondActivePointer != null; }
        protected bool IsSecondActivePointer(int pointerId)
        {
            if (_secondActivePointer != null)
                return _secondActivePointer.PointerId == pointerId;

            return false;
        }

        protected virtual void Reset()
        {
            _firstActivePointer = null;
            _secondActivePointer = null;
        }

        protected virtual void ResetFirstActivePointer() { _firstActivePointer = null; }
        protected virtual void ResetSecondActivePointer() { _secondActivePointer = null; }

        #endregion
    }
}