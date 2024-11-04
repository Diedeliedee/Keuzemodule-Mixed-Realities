using UnityEngine;

namespace GestureSystem.Testing
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float m_speed = 50f;

        private void Update()
        {
            transform.position += transform.forward * m_speed * Time.deltaTime;
        }
    }
}
