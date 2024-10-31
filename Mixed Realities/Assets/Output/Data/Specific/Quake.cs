using UnityEngine;

[CreateAssetMenu(fileName = "Quake", menuName = "Scriptable Object/Spell/AOE/Quake")]
public class Quake : AreaOfEffectData
{
    [Header("QUAKE SETTINGS")]
    [SerializeField] private float _innerRadius = 3f;
    [SerializeField] private float _middleRadius = 6f;
    [SerializeField] private int _innerDamage = 30;
    [SerializeField] private int _middleDamage = 20;
    [SerializeField] private int _outerDamage = 10;

    protected override void HandleEffect(Collider hit)
    {
        if (hit.TryGetComponent(out Health health))
        {
            float distanceToOrigin = Vector3.Distance(hit.transform.position, _FinalPosition);

            if (distanceToOrigin <= _innerRadius)
            {
                health.TakeDamage(_innerDamage);
            }
            else if (distanceToOrigin <= _middleRadius)
            {
                health.TakeDamage(_middleDamage);
            }
            else
            {
                health.TakeDamage(_outerDamage);
            }
        }
    }
}