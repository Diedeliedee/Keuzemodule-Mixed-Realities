using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Scriptable Object/Spell/Projectile")]
public class ProjectileData : SpellData
{
    [Header("PROJECTILE SETTINGS")]
    [SerializeField] private float _force = 10f;
    private LayerMask _targetLayer;

    public override void Init()
    {
        base.Init();

        _targetLayer = LayerMask.GetMask("DamageCollider");
    }

    public override void Cast(SpellContextPackage _package)
    {
        _package.direction  = _package.head.forward;
        _package.rotation   = _package.head.rotation;

        base.Cast(_package);

        _CurrentParticleSystem.GetComponent<Projectile>().Init(this, _targetLayer, _force);
    }
}