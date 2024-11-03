namespace GestureSystem
{
    [System.Flags]
    public enum FingerState
    {
        None        = 0,
        Straight    = 1,
        SlightBend  = 2,
        HalfBend    = 4,
        FullBend    = 8,
    }
}
