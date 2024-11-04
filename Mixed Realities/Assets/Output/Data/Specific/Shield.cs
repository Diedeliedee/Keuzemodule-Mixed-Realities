using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Scriptable Object/Spell/Shield")]
public class Shield : SpellData
{
    public override void Cast(Transform firePoint)
    {
        var temporaryFirepoint = new GameObject("Temporary Firepoint");

        temporaryFirepoint.transform.SetPositionAndRotation(firePoint.position, Quaternion.identity);

        base.Cast(temporaryFirepoint.transform);
        Destroy(temporaryFirepoint);

        // Set health.Invincible to true
    }

    protected override void Cleanup()
    {
        // Set health.Invincible to false

        base.Cleanup();
    }
}