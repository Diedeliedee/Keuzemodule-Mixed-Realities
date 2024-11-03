namespace GestureSystem
{
    [System.Flags]
    public enum FingerState
    {
        Straight    = 0,
        SlightBend  = 1,
        HalfBend    = 2,
        FullBend    = 4,
    }
}
