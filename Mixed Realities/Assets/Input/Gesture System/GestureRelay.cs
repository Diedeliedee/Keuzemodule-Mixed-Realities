using UnityEngine;
using UnityEngine.Events;

namespace GestureSystem
{
    public class GestureRelay : MonoBehaviour
    {
        [Header("Reference:")]
        [SerializeField] private SingleHandGestureMonitor m_leftHand;
        [SerializeField] private SingleHandGestureMonitor m_rightHand;

        [SerializeField] private GestureData m_testGesture;
        [SerializeField] private GameObject m_testGameObject;
        [Space]
        [SerializeField] private UnityEvent m_onConditionsMet;
        [SerializeField] private UnityEvent m_onConditionsNotMet;

        private void Update()
        {
            ActOnGesture(m_leftHand, m_testGesture.leftHand);
            ActOnGesture(m_rightHand, m_testGesture.rightHand);
        }

        private void ActOnGesture(SingleHandGestureMonitor _monitor, HandConditions _conditions)
        {
            if (_monitor.ConditionsMet(_conditions))
            {
                m_onConditionsMet.Invoke();
                TestLaunch(_monitor.firePoint);
            }

            m_onConditionsNotMet.Invoke();
        }

        private void TestLaunch(Transform _firePoint)
        {
            Instantiate(m_testGameObject, _firePoint.position, Quaternion.LookRotation(_firePoint.forward), null);
        }
    }
}
