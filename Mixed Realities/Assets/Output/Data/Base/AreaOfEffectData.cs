using UnityEngine;
using UnityEngine.AI;

public abstract class AreaOfEffectData : SpellData
{
    [Header("AREA OF EFFECT SETTINGS")]
    [SerializeField] private bool m_raycastEndpoint         = false;
    [SerializeField] private float _spellRadius             = 10f;
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
                _package.position   = hit.position;
                _package.rotation   = Quaternion.identity;
                _package.direction  = Vector3.zero;
            }
            else return;
        }
        else
        {
            _package.rotation   = Quaternion.LookRotation(_package.head.forward);
            _package.direction  = _package.head.forward;
        }

        base.Cast(_package);

        Collider[] hits = Physics.OverlapSphere(_FinalPosition, _spellRadius, _targetLayer);

        foreach (Collider collider in hits)
        {
            HandleEffect(collider);
        }
    }

    protected abstract void HandleEffect(Collider target);
}