using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Scriptable Object/Spell/Shield")]
public class Shield : SpellData
{
    public override void Cast(SpellContextPackage _package)
    {
        _package.position   = _package.origin.position;
        _package.rotation   = Quaternion.identity;
        _package.direction  = Vector3.zero;

        base.Cast(_package);

        // Set health.Invincible to true
    }

    protected override void Cleanup()
    {
        // Set health.Invincible to false

        base.Cleanup();
    }
}