using GestureSystem;
using UnityEngine;

public abstract class SpellData : ScriptableObject
{  
    [Header("CONDITION")]
    public GestureData gesture;

    [Header("PREFAB")]
    [SerializeField] protected ParticleSystem _Prefab;
    protected ParticleSystem _CurrentParticleSystem;
    protected Vector3 _FinalPosition;
    protected float _DeltaTime;

    [Header("SETTINGS")]
    [SerializeField] private float _offset;
    private float _timer;

    public virtual void Init()
    {
        // No idea yet
    }

    public virtual void Cast(SpellContextPackage _package)
    {
        if (_CurrentParticleSystem == null)
        {
            _FinalPosition          = _package.position + _package.direction * _offset;
            _CurrentParticleSystem  = Instantiate(_Prefab, _FinalPosition, _package.rotation);
            _timer                  = _CurrentParticleSystem.main.duration;
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