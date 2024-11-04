using UnityEngine;

namespace GestureSystem
{
    [CreateAssetMenu(fileName = "New Gesture", menuName = "Gestures/Gesture")]
    public class GestureData : ScriptableObject
    {
        [Header("Conditions:")]
        public HandConditions leftHand  = null;
        public HandConditions rightHand = null;

        [Header("Other Properties:")]
        public Type type = Type.PerHand;

        public enum Type
        {
            PerHand,
            BothHands
        }
    }
}