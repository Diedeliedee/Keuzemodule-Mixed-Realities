using UnityEngine;

[CreateAssetMenu(fileName = "New Shield", menuName = "Scriptable Object/Spell/Buff/Shield")]
public class Shield : BuffData
{
    [Header("SETTINGS")]
    [SerializeField] private float _duration = 3f;

    public override void Cast(Transform firePoint)
    {
        base.Cast(firePoint);

        // Not sure how to get the player health reference yet, but set Health.Invulnerable to true for the duration to apply the shield.
    }
}