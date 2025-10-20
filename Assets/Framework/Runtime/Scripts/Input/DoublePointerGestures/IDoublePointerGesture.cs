using UnityEngine;

namespace J_Framework
{
    public interface IDoublePointerGesture
    {
        void Initialize(int pointerId, Vector2 pointerPosition);
        void UpdateState(int pointerId, CustomPointerPhase phase, Vector2 pointerPosition);
        void Update(float deltaTime);
    }
}