﻿using UnityEngine;
using UnityEngine.Events;

namespace GestureSystem
{
    public class GestureRelay : MonoBehaviour
    {
        [SerializeField] private HandReader m_rightHandReader;
        [SerializeField] private MovementReader m_rightVelocityReader;
        [SerializeField] private OrientationReader m_rightOrientationReader;
        [Space]
        [SerializeField] private Gesture m_testGesture;
        [Space]
        [SerializeField] private UnityEvent<GestureData> m_onConditionsMet;
        [SerializeField] private UnityEvent m_onConditionsNotMet;

        private void Update()
        {
            //  For now, testing with the right hand.
            if (!m_rightHandReader.TryGetCurlData(out float[] _curlData))
            {
                m_onConditionsNotMet.Invoke();
                return;
            }
            if (!FingerComparer.FingersMatch(m_testGesture.rightHand.fingers.states, _curlData))
            {
                m_onConditionsNotMet.Invoke();
                return;
            }
            if (!MovementComparer.MatchesVelocity(m_testGesture.rightHand.movement.velocity, m_rightVelocityReader.orientalVelocity))
            {
                return;
            }
            if (!OrientationComparer.MatchesDirection(m_testGesture.rightHand.orientation, m_rightOrientationReader.GetLocalOrientation()))
            {
                m_onConditionsNotMet.Invoke();
                return;
            }

            m_onConditionsMet.Invoke(new());
        }
    }
}
