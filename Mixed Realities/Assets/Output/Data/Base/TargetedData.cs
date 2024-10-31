using UnityEngine;

public abstract class TargetedData : SpellData
{
    [Header("TARGETED SETTINGS")]
    [SerializeField] private float _spellRange = 10;
    private LayerMask _targetLayer;

    public override void Init()
    {
        base.Init();

        _targetLayer = LayerMask.GetMask("DamageCollider");
    }

    public override void Cast(Transform firePoint)
    {
        base.Cast(firePoint);

        if (Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hit, _spellRange, _targetLayer))
        {
            HandleEffect(hit.collider, firePoint);
        }
    }

    protected abstract void HandleEffect(Collider target, Transform firePoint);
}