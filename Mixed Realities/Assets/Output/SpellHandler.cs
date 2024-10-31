using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    [Header("SPELL SELECTION")]
    [SerializeField] private List<SpellData> _spells = new();

    // Delete later, hands will be firepoint
    public Transform FirePoint;

    private void Awake()
    {
        foreach (SpellData spell in _spells)
        {
            spell.Init();
        }
    }

    private void Update()
    {
        foreach (SpellData spell in _spells)
        {
            if (Input.GetKeyDown(spell.KeyCode))
            {
                spell.Cast(FirePoint);
            }
        }
    }
}