using System.Collections.Generic;
using UnityEngine;

namespace GestureSystem.Legacy
{
    //[CreateAssetMenu(fileName = "New Gesture", menuName = "Scriptable Object/Gesture")]
    public class Gesture : ScriptableObject
    {
        [Header("GESTURE TYPE")]
        public GestureType gestureType;

        [Header("LEFT HAND FINGER SHAPE CONDITIONS")]
        public List<FingerShapeCondition> LeftHandFingerConditions;

        [Header("RIGHT HAND FINGER SHAPE CONDITIONS")]
        public List<FingerShapeCondition> RightHandFingerConditions;

        [Header("REQUIRES BOTH HANDS")]
        public bool RequiresBothHands;
    }
}