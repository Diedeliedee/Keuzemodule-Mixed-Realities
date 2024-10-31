using UnityEngine;

public class Health : MonoBehaviour
{
    public bool Invulnerable { private get; set; }

    [Header("SETTINGS")]
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        _currentHealth = _maxHealth;
    }

    public void Cleanup()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        if (Invulnerable) return;

        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Cleanup();
        }
        else
        {
            Debug.Log($"{amount} damage taken. Current health is: {_currentHealth}");
        }
    }
}