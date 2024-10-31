using System.Collections.Generic;
using UnityEngine;

public abstract class ParticleCollision : MonoBehaviour
{
    [Header("PARTICLE COLLISION SETTINGS")]
    [SerializeField] private int _maxTriggers = 1;

    private Dictionary<GameObject, int> _collisionCounts;
    private LayerMask _targetLayer;

    public void Init(LayerMask targetLayer)
    {
        _collisionCounts = new();
        _targetLayer = targetLayer;
    }

    private void OnParticleCollision(GameObject collision)
    {
        if (((1 << collision.layer) & _targetLayer) != 0)
        {
            if (!_collisionCounts.ContainsKey(collision))
            {
                _collisionCounts[collision] = 0;
            }

            if (_collisionCounts[collision] < _maxTriggers)
            {
                _collisionCounts[collision]++;
                Collision(collision);
            }
        }
    }

    protected abstract void Collision(GameObject collision);
}