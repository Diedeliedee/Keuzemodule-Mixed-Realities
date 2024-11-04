using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Gestures;

namespace GestureSystem
{
    public class FingerReader : MonoBehaviour
    {
        [Header("Properties:")]
        [Tooltip("The event handler from which hand the reader should get it's data from. This is very important for determining which hand this reader will track!")]
        [SerializeField] private XRHandTrackingEvents m_events;

        //  Array containing the finger shapes.
        private XRFingerShape[] m_shapes    = new XRFingerShape[FingerConditions.fingerCount];
        private bool m_active               = false;

        private void Awake()
        {
            m_events.trackingAcquired.AddListener(OnTrackingAcquired);
            m_events.trackingLost.AddListener(OnTrackingLost);
        }

        private void OnTrackingAcquired()
        {
            m_active = true;
            m_events.jointsUpdated.AddListener(OnJointsUpdated);
        }

        private void OnTrackingLost()
        {
            m_active = false;
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
            //  Create a new float.
            _curlData = new float[FingerConditions.fingerCount];

            //  If the hand is inactive, disregard the hand's curl data.
            if (!m_active)
            {
                _curlData = null;
                return false;
            }

            for (int i = 0; i < m_shapes.Length; i++)
            {
                /// If for some reason we can't get a finger, best to disregard the hand entirely.
                if (!m_shapes[i].TryGetFullCurl(out float _curl))
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
