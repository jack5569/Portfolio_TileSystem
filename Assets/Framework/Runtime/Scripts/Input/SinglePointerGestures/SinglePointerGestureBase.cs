using UnityEngine;

namespace J_Framework
{
    public abstract class SinglePointerGestureBase : ISinglePointerGesture
    {
        private PointerInfo _activePointer;

        protected PointerInfo ActivePointer => _activePointer;

        public virtual void Initialize(int pointerId, Vector2 position)
        {
            _activePointer = new PointerInfo(pointerId, position);
        }

        public virtual void Update(float deltaTime)
        {
        }

        public virtual void UpdateState(int pointerId, CustomPointerPhase phase, Vector2 position)
        {
            if (!IsActivePointer(pointerId))
                return;

            _activePointer.Update(phase, position);
        }

        #region Protected methods

        protected bool IsActivePointer(int pointerId)
        {
            if (_activePointer != null)
                return _activePointer.PointerId == pointerId;

            return false;
        }

        protected virtual void Reset()
        {
            _activePointer = null;
        }

        #endregion
    }
}