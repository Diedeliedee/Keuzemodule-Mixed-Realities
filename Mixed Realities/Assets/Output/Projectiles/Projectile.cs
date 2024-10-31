using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public abstract class Projectile : MonoBehaviour
{
    protected Transform _Transform;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private LayerMask _targetLayer;
    private Vector3 _startPos;
    private float _range;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _targetLayer) != 0)
        {
            // This does not work
        }

        Collision(other);
    }

    public void Init(LayerMask targetLayer, float force, float range)
    {
        _Transform = transform;
        _targetLayer = targetLayer;
        _startPos = _Transform.position;
        _range = range;

        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        _rigidbody.useGravity = false;

        _collider.isTrigger = true;

        _rigidbody.AddForce(force * _Transform.forward, ForceMode.Impulse);

        StartCoroutine(RangeCoroutine());
    }

    protected abstract void Collision(Collider other);

    protected virtual void Tick()
    {
        Vector3 currentPos = _Transform.position;
        float distance = Vector3.Distance(_startPos, currentPos);

        if (distance >= _range)
        {
            Cleanup();
        }
    }

    protected virtual void Cleanup()
    {
        Destroy(gameObject);
    }

    private IEnumerator RangeCoroutine()
    {
        while (true)
        {
            yield return null;

            Tick();
        }
    }
}