using UnityEngine;

[CreateAssetMenu(fileName = "Gravity Pull", menuName = "Scriptable Object/Spell/Targeted/Gravity Pull")]
public class GravityPullData : TargetedData
{
    [Header("GRAVITY PULL SETTINGS")]
    [SerializeField] private float pullStrength = 5f;

    protected override void HandleEffect(Collider target, Transform firePoint)
    {
        if (target.TryGetComponent(out Rigidbody rigidbody))
        {
            Vector3 directionToPull = (firePoint.position - target.transform.position).normalized;
            rigidbody.AddForce(directionToPull * pullStrength, ForceMode.Impulse);
        }
    }
}