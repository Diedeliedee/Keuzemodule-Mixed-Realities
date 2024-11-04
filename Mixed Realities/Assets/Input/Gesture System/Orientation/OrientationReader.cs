using UnityEngine;

namespace GestureSystem
{
    public class OrientationReader : MonoBehaviour
    {
        [SerializeField] private Transform m_handOrigin;
        [SerializeField] private Transform m_reference;

        public Vector3 GetLocalOrientation()
        {
            var shit =  m_reference.InverseTransformDirection(m_handOrigin.forward); return shit;
        }
    }
}
