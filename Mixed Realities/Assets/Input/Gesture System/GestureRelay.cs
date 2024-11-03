﻿using UnityEngine;
using UnityEngine.Events;

namespace GestureSystem
{
    public class GestureRelay : MonoBehaviour
    {
        [SerializeField] private HandReader m_leftHandReader;
        [SerializeField] private HandReader m_rightHandReader;
        [Space]
        [SerializeField] private Gesture m_testGesture;

        private UnityEvent<GestureData> m_onConditionsMet;

        private void Update()
        {
            //  For now, testing with the right hand.
            if (!m_rightHandReader.TryGetCurlData(out float[] _curlData))                               return;
            if (!FingerComparer.FingersMatch(m_testGesture.m_rightHandConditions.m_states, _curlData))  return;

            m_onConditionsMet.Invoke(new());
        }
    }
}
