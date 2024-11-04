using UnityEngine;

public abstract class TargetedData : SpellData
{
    [Header("TARGETED SETTINGS")]
    [SerializeField] private float _spellRadius = 3;
    [SerializeField] private float _spellRange = 10;
    private LayerMask _targetLayer;

    public override void Init()
    {
        base.Init();

        _targetLayer = LayerMask.GetMask("DamageCollider");
    }

    public override void Cast(SpellContextPackage _package)
    {
        _package.position   = _package.head.position;
        _package.rotation   = Quaternion.LookRotation(_package.head.forward);
        _package.direction  = _package.head.forward;

        base.Cast(_package);

        if (Physics.SphereCast(_package.position, _spellRadius, _package.direction, out RaycastHit hit, _spellRange, _targetLayer))
        {
            HandleEffect(hit.collider, _package.firePoint);
        }
    }

    protected abstract void HandleEffect(Collider target, Transform firePoint);
}