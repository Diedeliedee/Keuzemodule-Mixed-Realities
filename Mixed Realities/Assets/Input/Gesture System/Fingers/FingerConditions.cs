namespace GestureSystem
{
    [System.Serializable]
    public class FingerConditions
    {
        public const int fingerCount = 5;

        public FingerState m_thumb;
        public FingerState m_index;
        public FingerState m_middle;
        public FingerState m_ring;
        public FingerState m_pinky;

        public FingerState[] m_states
        {
            get => new FingerState[] { m_thumb, m_index, m_middle, m_ring, m_pinky };
        }
    }
}
