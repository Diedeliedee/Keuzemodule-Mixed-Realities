using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Gestures;

namespace GestureSystem
{
    internal class HandReader : MonoBehaviour
    {
        [Header("Properties:")]
        [Tooltip("The event handler from which hand the reader should get it's data from. This is very important for determining which hand this reader will track!")]
        [SerializeField] private XRHandTrackingEvents m_events;

        //  Array containing the finger shapes.
        private XRFingerShape[] m_shapes = new XRFingerShape[5];

        private void OnEnable()
        {
            m_events.jointsUpdated.AddListener(OnJointsUpdated);
        }

        private void OnDisable()
        {
            m_events.jointsUpdated.RemoveListener(OnJointsUpdated);
        }

        /// <summary>
        /// Function that updates the finger shape with the latest incoming data.
        /// </summary>
        private void OnJointsUpdated(XRHandJointsUpdatedEventArgs _args)
        {
            for (int i = 0; i < m_shapes.Length; i++)
            {
                m_shapes[i] = XRFingerShapeMath.CalculateFingerShape(_args.hand, (XRHandFingerID)i, XRFingerShapeTypes.All);
            }
        }

        /// <summary>
        /// Function that retrieves the curl data from all fingers, and returns it if all of the data is accessible.
        /// </summary>
        public bool TryGetCurlData(out float[] _curlData)
        {
            _curlData = new float[5];

            for (int i = 0; i < m_shapes.Length; i++)
            {
                /// If for some reason we can't get a finger, best to disregard the hand entirely.
                /// Since it'll most likely return false if the hand is off-screen.
                if (m_shapes[i].TryGetFullCurl(out float _curl))
                {
                    _curlData = null;
                    return false;
                }
                _curlData[i] = _curl;
            }

            return true;
        }
    }
}
