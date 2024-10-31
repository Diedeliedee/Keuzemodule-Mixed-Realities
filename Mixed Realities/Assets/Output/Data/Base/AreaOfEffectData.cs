using UnityEngine;

public abstract class AreaOfEffectData : SpellData
{
    [Header("AREA OF EFFECT SETTINGS")]
    [SerializeField] private float _spellRadius = 10f;
    private LayerMask _targetLayer;

    public override void Init()
    {
        base.Init();

        _targetLayer = LayerMask.GetMask("DamageCollider");
    }

    public override void Cast(Transform firePoint)
    {
        base.Cast(firePoint);

        Collider[] hits = Physics.OverlapSphere(_FinalPosition, _spellRadius, _targetLayer);

        foreach (Collider hit in hits)
        {
            HandleEffect(hit);
        }
    }

    protected abstract void HandleEffect(Collider target);
}