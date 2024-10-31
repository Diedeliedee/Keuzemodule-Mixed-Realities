using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Scriptable Object/Spell/Shield")]
public class Shield : SpellData
{
    public override void Cast(Transform firePoint)
    {
        base.Cast(firePoint);

        // Set health.Invincible to true
    }

    protected override void Cleanup()
    {
        // Set health.Invincible to false

        base.Cleanup();
    }
}