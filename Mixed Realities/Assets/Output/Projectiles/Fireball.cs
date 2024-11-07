using UnityEngine;

public class Fireball : Projectile
{
    [Header("PREFAB")]
    [SerializeField] private Explosion _explosionPrefab;

    [Header("SETTINGS")]
    [SerializeField] private int _damage;

    protected override void Collision(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }

        Explosion explosion = Instantiate(_explosionPrefab, _Transform.position, Quaternion.identity);
        explosion.Init();
        _SpellData.Cleanup();
    }
}