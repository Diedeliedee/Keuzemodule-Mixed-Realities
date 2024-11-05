using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("SETTINGS")]
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;

    public virtual void Init()
    {
        List<Collider> hits = new();
        hits.AddRange(Physics.OverlapSphere(transform.position, _radius, LayerMask.GetMask("DamageCollider")));

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(_damage);
            }
        }

        Invoke(nameof(DestroyExplosion), 3f);
    }

    private void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}