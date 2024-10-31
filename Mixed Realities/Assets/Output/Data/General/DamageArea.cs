using UnityEngine;

[CreateAssetMenu(fileName = "Damage Area", menuName = "Scriptable Object/Spell/AOE/Damage")]
public class DamageArea : AreaOfEffectData
{
    [Header("DAMAGE AREA SETTINGS")]
    [SerializeField] private int _damage;

    protected override void HandleEffect(Collider target)
    {
        if (target.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }
    }
}