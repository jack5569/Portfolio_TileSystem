using System;

namespace J_Framework
{
    [Flags]
    public enum PointerGesture
    {
        Tap = 1 << 0,
        Click = 1 << 1,
        Drag = 1 << 2,
        Hold = 1 << 3,
        Swipe = 1 << 4,
        Spread = 1 << 5,
        All = ~0
    }
}