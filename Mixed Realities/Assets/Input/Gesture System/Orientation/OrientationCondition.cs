using System;

namespace GestureSystem
{
    [Flags]
    public enum Orientation
    {
         None       = 0,
         Forward    = 1,
         Backward   = 2,
         Left       = 4,
         Right      = 8,
         Upward     = 16,
         Downward   = 32,
    }
}
