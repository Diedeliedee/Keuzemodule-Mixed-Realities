using UnityEngine;

namespace GestureSystem
{
    /// <summary>
    /// Momentary cheap way to detect if a hand is moving the desired way.
    /// As earlier described, this method allows the user to "flick" their spell, which is undesired.
    /// But for testing purposes it shall have to do.
    /// </summary>
    public class MovementReader : MonoBehaviour
    {
        [SerializeField] private Transform m_handOrigin;
        [SerializeField] private Transform m_directionReference;
        [Space]
        [SerializeField] private bool m_drawGizmos;

        private Vector3 m_currentPosition   = Vector3.zero;
        private Vector3 m_previousPosition  = Vector3.zero;
        private Vector3 m_velocity          = Vector3.zero;
        private Vector3 m_orientalVelocity  = Vector3.zero;

        public Vector3 position         => m_currentPosition;
        public Vector3 orientalVelocity => m_orientalVelocity;

        private void Start()
        {
            m_currentPosition   = m_handOrigin.position;
            m_previousPosition  = m_handOrigin.position;
        }

        private void Update()
        {
            //  Calculating the oriental velocity.
            m_currentPosition   = m_handOrigin.position;
            m_velocity          = (m_currentPosition - m_previousPosition) / Time.deltaTime;
            m_orientalVelocity  = m_directionReference.InverseTransformDirection(m_velocity);

            //  Saving the previous position for next frame.
            m_previousPosition = m_currentPosition;
        }

        private void OnDrawGizmosSelected()
        {
            if (!m_drawGizmos)          return;
            if (!Application.isPlaying) return;

            Gizmos.color = Color.blue;
            Gizmos.DrawRay(m_currentPosition, m_velocity);
        }
    }
}
