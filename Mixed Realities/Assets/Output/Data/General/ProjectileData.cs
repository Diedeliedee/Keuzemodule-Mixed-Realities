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

    public override void Cast(Transform firePoint)
    {
        base.Cast(firePoint);

        _CurrentParticleSystem.GetComponent<Projectile>().Init(_targetLayer, _force);
    }
}