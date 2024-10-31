using UnityEngine;

public abstract class SpellData : ScriptableObject
{  
    [Header("CONDITION")]
    public KeyCode KeyCode;

    [Header("PREFAB")]
    [SerializeField] protected ParticleSystem _Prefab;
    protected ParticleSystem _CurrentParticleSystem;
    protected Vector3 _FinalPosition;
    protected float _DeltaTime;

    [Header("SETTINGS")]
    [SerializeField] private Vector3 _offset;
    private float _timer;

    public virtual void Init()
    {
        // No idea yet
    }

    public virtual void Cast(Transform firePoint)
    {
        if (_CurrentParticleSystem == null)
        {
            _FinalPosition = firePoint.localPosition + _offset;
            _CurrentParticleSystem = Instantiate(_Prefab, _FinalPosition, Quaternion.identity);
            _timer = _CurrentParticleSystem.main.duration;
        }
    }

    public virtual void Tick(float deltaTime)
    {
        if (_CurrentParticleSystem != null)
        {
            _DeltaTime = deltaTime;
            _timer -= deltaTime;
            if (_timer <= 0)
            {
                Cleanup();
            }
        }
    }

    protected virtual void Cleanup()
    {
        Destroy(_CurrentParticleSystem.gameObject);
        _CurrentParticleSystem = null;
    }
}