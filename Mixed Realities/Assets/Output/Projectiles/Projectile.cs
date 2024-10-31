using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public abstract class Projectile : MonoBehaviour
{
    protected Transform _Transform;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private LayerMask _targetLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _targetLayer) != 0)
        {
            Collision(other);
        }
    }

    public void Init(LayerMask targetLayer, float force)
    {
        _Transform = transform;
        _targetLayer = targetLayer;

        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        _rigidbody.useGravity = false;

        _collider.isTrigger = true;

        _rigidbody.AddForce(force * _Transform.forward, ForceMode.Impulse);
    }

    protected abstract void Collision(Collider other);
}