using UnityEngine;

public class DamageParticleCollision : ParticleCollision
{
    [Header("DAMAGE SETTINGS")]
    [SerializeField] private int _damage;

    protected override void Collision(GameObject collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }
    }
}
