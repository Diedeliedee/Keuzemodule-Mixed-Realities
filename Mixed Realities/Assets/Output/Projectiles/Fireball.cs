using UnityEngine;

public class Fireball : Projectile
{
    [Header("SETTINGS")]
    [SerializeField] private int _damage;

    protected override void Collision(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }
    }
}