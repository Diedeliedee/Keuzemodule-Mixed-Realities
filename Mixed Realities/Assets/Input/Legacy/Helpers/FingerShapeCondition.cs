using UnityEngine.XR.Hands.Gestures;
using System.Collections.Generic;
using UnityEngine.XR.Hands;
using UnityEngine;
using System;

namespace GestureSystem.Legacy
{
    [Serializable]
    public class FingerShapeCondition
    {
        [Header("FINGER ID")]
        public XRHandFingerID FingerID;

        [Header("ALLOWED SHAPES")]
        public List<XRFingerShapeType> AllowedShapes;
    }
}