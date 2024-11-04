using UnityEngine;

namespace GestureSystem
{
    [CreateAssetMenu(fileName = "New Hand Condition", menuName = "Gestures/Hand Condition")]
    public class HandConditions : ScriptableObject
    {
        [SerializeField] private FingerConditions m_fingers     = default;
        [SerializeField] private MovementConditions m_movement  = default;

        public FingerConditions fingers     => m_fingers;
        public MovementConditions movement  => m_movement;
    }
}
