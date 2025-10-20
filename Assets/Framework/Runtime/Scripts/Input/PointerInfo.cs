using UnityEngine;

namespace J_Framework
{
    public class PointerInfo
    {
        private int _pointerId = -99;
        private CustomPointerPhase _phase = CustomPointerPhase.OffScreen;
        private Vector2 _startPosition;
        private Vector2 _previousPosition;
        private Vector2 _currentPosition;

        public int PointerId => _pointerId;
        public CustomPointerPhase Phase => _phase;
        public Vector2 StartPosition => _startPosition;
        public Vector2 PreviousPosition => _previousPosition;
        public Vector2 CurrentPosition => _currentPosition;

        public PointerInfo(int pointerId, Vector2 position)
        {
            _pointerId = pointerId;
            _phase = CustomPointerPhase.OnScreen;
            _startPosition = position;
            _previousPosition = position;
            _currentPosition = position;
        }

        public void Update(CustomPointerPhase phase, Vector2 position)
        {
            _phase = phase;
            _previousPosition = _currentPosition;
            _currentPosition = position;
        }
    }
}