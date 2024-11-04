using UnityEngine;

namespace GestureSystem
{
    [CreateAssetMenu(fileName = "New Gesture", menuName = "Scriptable Object/Gesture")]
    public class Gesture : ScriptableObject
    {
        [Header("Finger Conditions:")]
        public FingerConditions m_leftHandConditions    = default;
        public FingerConditions m_rightHandConditions   = default;

        [Header("Other Properties:")]
        public Type m_type = Type.PerHand;

        public enum Type
        {
            PerHand,
            BothHands
        }
    }
}