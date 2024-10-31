using UnityEngine;

[CreateAssetMenu(fileName = "New Collision", menuName = "Scriptable Object/Spell/Collision")]
public class CollisionData : SpellData
{
    private LayerMask _targetLayer;

    public override void Init()
    {
        base.Init();

        _targetLayer = LayerMask.GetMask("DamageCollider");
    }

    public override void Cast(Transform firePoint)
    {
        base.Cast(firePoint);

        ParticleCollision[] particleCollisions = _CurrentParticleSystem.GetComponentsInChildren<ParticleCollision>();
        foreach (var particleCollision in particleCollisions)
        {
            particleCollision.Init(_targetLayer);
        }
    }
}