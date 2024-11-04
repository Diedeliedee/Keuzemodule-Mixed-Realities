namespace GestureSystem
{
    [System.Serializable]
    public class FingerConditions
    {
        public const int fingerCount = 5;

        public FingerState thumb;
        public FingerState index;
        public FingerState middle;
        public FingerState ring;
        public FingerState pinky;

        public FingerState[] states
        {
            get => new FingerState[] { thumb, index, middle, ring, pinky };
        }
    }
}
