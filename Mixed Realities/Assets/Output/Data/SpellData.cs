using UnityEngine;

public abstract class SpellData : ScriptableObject
{  
    [Header("CONDITION")]
    public KeyCode KeyCode;

    [Header("POSITION")]
    public Vector3 Offset;

    public abstract void Init();

    public abstract void Cast(Transform firePoint);
}