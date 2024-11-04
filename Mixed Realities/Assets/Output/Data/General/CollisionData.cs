using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New Collision", menuName = "Scriptable Object/Spell/Collision")]
public class CollisionData : SpellData
{
    [Header("COLLISION DATA SPECIFIC")]
    [SerializeField] private bool m_raycastEndpoint = false;

    private LayerMask _targetLayer;

    public override void Init()
    {
        base.Init();

        _targetLayer = LayerMask.GetMask("DamageCollider");
    }

    public override void Cast(Transform firePoint)
    {
        GameObject temporaryFirepoint;

        if (m_raycastEndpoint &&
            Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit info, Mathf.Infinity) &&
            NavMesh.SamplePosition(info.point, out NavMeshHit hit, Mathf.Infinity, NavMesh.AllAreas))
        {
            temporaryFirepoint = new GameObject("Temporary Firepoint");
            temporaryFirepoint.transform.SetPositionAndRotation(hit.position, Quaternion.identity);

            base.Cast(temporaryFirepoint.transform);
            Destroy(temporaryFirepoint);
        }
        else
        {
            base.Cast(firePoint);
        }

        ParticleCollision[] particleCollisions = _CurrentParticleSystem.GetComponentsInChildren<ParticleCollision>();
        foreach (var particleCollision in particleCollisions)
        {
            particleCollision.Init(_targetLayer);
        }
    }
}