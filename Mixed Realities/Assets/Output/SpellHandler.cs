using GestureSystem;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    [Header("SPELL SELECTION")]
    [SerializeField] private List<SpellData> _spells = new();

    private GestureRelay m_relay = null;

    private void Awake()
    {
        foreach (SpellData spell in _spells)
        {
            spell.Init();
        }

        m_relay = FindObjectOfType<GestureRelay>();
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;

        foreach (SpellData spell in _spells)
        {
            if (m_relay.MonitorForCasts(_spells.ToArray(), out GestureRelay.CallbackPackage _package))
            {
                _package.succeededSpell.Cast(_package.firePoint);
            }

            spell.Tick(deltaTime);
        }
    }
}