using UnityEngine;

namespace GestureSystem
{
    [CreateAssetMenu(fileName = "New Hand Condition", menuName = "Gestures/Hand Condition")]
    public class HandConditions : ScriptableObject
    {
        [SerializeField] private FingerConditions m_fingers     = default;
        [Space]
        [SerializeField] private MovementConditions m_movement  = default;
        [Space]
        [SerializeField] private Orientation m_orientation      = default;

        public FingerConditions fingers     => m_fingers;
        public MovementConditions movement  => m_movement;
        public Orientation orientation      => m_orientation;
    }
}
