using UnityEngine;

[CreateAssetMenu(fileName = "Laser Beam", menuName = "Scriptable Object/Spell/AOE/Laser Beam")]
public class LaserBeam : AreaOfEffectData
{
    [Header("LASER BEAM SETTINGS")]
    [SerializeField] private float _innerRadius = 1.0f;
    [SerializeField] private int _innerDamage = 50;        
    [SerializeField] private int _outerDamage = 25;        

    protected override void HandleEffect(Collider hit)
    {
        if (hit.TryGetComponent(out Health health))
        {
            float distanceToOrigin = Vector3.Distance(hit.transform.position, _FinalPosition);

            if (distanceToOrigin <= _innerRadius)
            {
                health.TakeDamage(_innerDamage);
            }
            else
            {
                health.TakeDamage(_outerDamage);
            }
        }
    }
}