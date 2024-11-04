using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New Collision", menuName = "Scriptable Object/Spell/Collision")]
public class CollisionData : SpellData
{
    [Header("COLLISION DATA SPECIFIC")]
    [SerializeField] private bool m_raycastEndpoint         = false;
    [SerializeField] private LayerMask m_environmentMask    = default;

    private LayerMask _targetLayer;

    public override void Init()
    {
        base.Init();

        _targetLayer = LayerMask.GetMask("DamageCollider");
    }

    public override void Cast(SpellContextPackage _package)
    {
        if (m_raycastEndpoint)
        {
            if (Physics.Raycast(_package.firePoint.position, _package.head.forward, out RaycastHit info, Mathf.Infinity, m_environmentMask) &&
                NavMesh.SamplePosition(info.point, out NavMeshHit hit, Mathf.Infinity, NavMesh.AllAreas))
            {
                _package.position = hit.position;
                _package.rotation = Quaternion.identity;
                _package.direction = Vector3.zero;
            }
            else return;
        }
        else
        {
            _package.rotation   = Quaternion.LookRotation(_package.head.forward);
            _package.direction  = _package.head.forward;
        }

        base.Cast(_package);

        ParticleCollision[] particleCollisions = _CurrentParticleSystem.GetComponentsInChildren<ParticleCollision>();
        foreach (var particleCollision in particleCollisions)
        {
            particleCollision.Init(_targetLayer);
        }
    }
}