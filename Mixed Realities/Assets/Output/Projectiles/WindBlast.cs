using UnityEngine;

public class WindBlast : Projectile
{
    [Header("SETTINGS")]
    [SerializeField] private float _force = 15f;

    protected override void Collision(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rigidbody))
        {
            Vector3 direction = (other.transform.position - _Transform.position).normalized;
            rigidbody.AddForce(_force * direction, ForceMode.Impulse);
        }
    }
}