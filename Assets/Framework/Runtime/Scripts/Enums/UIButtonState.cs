using System;

namespace J_Framework
{
    [Flags]
    public enum UIButtonState
    {
        Normal = 1 << 0,
        Highlighted = 1 << 1,
        Pressed = 1 << 2,
        Selected = 1 << 3,
        Disabled = 1 << 4
    }
}
