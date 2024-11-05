using UnityEngine;

namespace GestureSystem
{
    public class SingleHandGestureMonitor : MonoBehaviour
    {
        [SerializeField] private float m_cooldown = 1f;
        [SerializeField] private Transform m_firePoint;

        private FingerReader m_fingerReader             = null;
        private MovementReader m_movementReader         = null;
        private OrientationReader m_orientationReader   = null;
        private SpellFeedbackHandler m_feedback         = null;

        private bool m_cast = false;
        private float m_cooldownTimer = 0f;

        public Transform firePoint => m_firePoint;

        public void Awake()
        {
            m_fingerReader      = GetComponent<FingerReader>();
            m_movementReader    = GetComponent<MovementReader>();
            m_orientationReader = GetComponent<OrientationReader>();

            m_feedback = GetComponentInChildren<SpellFeedbackHandler>();
        }

        private void Update()
        {
            if (m_cast)
            {
                m_cooldownTimer += Time.deltaTime;
                m_feedback.TickCooldown();
                if (m_cooldownTimer >= m_cooldown) 
                {
                    {
                        m_cast = false;
                        m_cooldownTimer = 0f;
                    } 
                }
            }
        }

        public bool ConditionsMet(HandConditions _conditions)
        {
            if (m_cast) return false;

            //  Probing whether we can even read the finger data at all.
            if (!m_fingerReader.TryGetCurlData(out float[] _curlData))
            {
                //  Conditions not met!
                return false;
            }

            //  First, we test if the hand is moving the right way.
            if (!MovementComparer.MatchesVelocity(_conditions.movement.velocity, m_movementReader.orientalVelocity))
            {
                //  Conditions not met!
                return false;
            }

            //  Then we test if the hand is even in the right direction.
            if (!OrientationComparer.MatchesDirection(_conditions.orientation, m_orientationReader.GetLocalOrientation()))
            {
                //  Conditions not met!
                return false;
            }

            //  Finally, we test to see if the finger gesture matches.
            if (!FingerComparer.FingersMatch(_conditions.fingers.states, _curlData))
            {
                //  Conditions not met!
                return false;
            }

            m_feedback.ProvideFeedback();
            m_cast = true;
            return true;
        }
    }
}