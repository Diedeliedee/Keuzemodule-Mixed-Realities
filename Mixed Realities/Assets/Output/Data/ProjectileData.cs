using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Scriptable Object/Spell/Projectile")]
public class ProjectileData : SpellData
{
    [Header("PREFAB")]
    [SerializeField] private Projectile _projectilePrefab;

    [Header("SETTINGS")]
    [SerializeField] private float _force = 10f;
    [SerializeField] private float _range = 15f;
    private LayerMask _targetLayer;

    public override void Init()
    {
        _targetLayer = LayerMask.NameToLayer("DamageCollider");
    }

    public override void Cast(Transform firePoint)
    {
        Projectile projectile = Instantiate(_projectilePrefab, firePoint);
        projectile.Init(_targetLayer, _force, _range);
    }
}