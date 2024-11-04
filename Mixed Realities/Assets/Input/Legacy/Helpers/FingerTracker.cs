using UnityEngine.XR.Hands.Gestures;
using System.Collections.Generic;
using UnityEngine.XR.Hands;
using UnityEngine;

namespace GestureSystem.Legacy
{
    public class FingerTracker
    {
        private Dictionary<Handedness, Dictionary<XRHandFingerID, XRFingerShape>> _fingerShapes;

        public FingerTracker()
        {
            _fingerShapes = new Dictionary<Handedness, Dictionary<XRHandFingerID, XRFingerShape>>
        {
            { Handedness.Left, new Dictionary<XRHandFingerID, XRFingerShape>() },
            { Handedness.Right, new Dictionary<XRHandFingerID, XRFingerShape>() }
        };

            foreach (XRHandFingerID fingerID in (XRHandFingerID[])System.Enum.GetValues(typeof(XRHandFingerID)))
            {
                _fingerShapes[Handedness.Left][fingerID] = new XRFingerShape();
                _fingerShapes[Handedness.Right][fingerID] = new XRFingerShape();
            }
        }

        public void UpdateFingerShape(XRHand hand)
        {
            foreach (XRHandFingerID fingerID in _fingerShapes[hand.handedness].Keys)
            {
                XRFingerShape fingerShape = XRFingerShapeMath.CalculateFingerShape(hand, fingerID,
                XRFingerShapeTypes.Pinch | XRFingerShapeTypes.FullCurl | XRFingerShapeTypes.BaseCurl | XRFingerShapeTypes.Spread);

                _fingerShapes[hand.handedness][fingerID] = fingerShape;
            }
        }

        public Dictionary<XRHandFingerID, XRFingerShape> GetFingerShapes(Handedness handedness)
        {
            return _fingerShapes[handedness];
        }
    }
}