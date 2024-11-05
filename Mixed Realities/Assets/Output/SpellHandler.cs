using System.Collections.Generic;
using GestureSystem;
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
                var spellPackage = new SpellContextPackage()
                {
                    firePoint   = _package.firePoint,
                    origin      = _package.userOrigin,
                    head        = _package.userHead,

                    position    = _package.firePoint.position,
                    rotation    = _package.firePoint.rotation,
                    direction   = _package.firePoint.forward
                };

                _package.succeededSpell.Cast(spellPackage);
            }

            spell.Tick(deltaTime);
        }
    }
}