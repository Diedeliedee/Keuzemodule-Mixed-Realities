using UnityEngine;
using UnityEngine.Events;

namespace GestureSystem
{
    public class GestureRelay : MonoBehaviour
    {
        [Header("Reference:")]
        [SerializeField] private SingleHandGestureMonitor m_leftHand;
        [SerializeField] private SingleHandGestureMonitor m_rightHand;

        public bool MonitorForCasts(SpellData[] _spells, out CallbackPackage _package)
        {
            foreach (var spell in _spells)
            {
                if (spell.gesture == null) continue;

                switch (spell.gesture.type)
                {
                    case GestureData.Type.PerHand:
                    {
                        if (m_leftHand.ConditionsMet(spell.gesture.leftHand))
                        {
                            _package = new() { succeededSpell = spell, firePoint = m_leftHand.firePoint };
                            return true;
                        }
                        if (m_rightHand.ConditionsMet(spell.gesture.rightHand))
                        {
                            _package = new() { succeededSpell = spell, firePoint = m_rightHand.firePoint };
                            return true;
                        }
                        break;
                    }

                    case GestureData.Type.BothHands:
                    {
                        if (!m_leftHand.ConditionsMet(spell.gesture.leftHand)) break;
                        if (!m_rightHand.ConditionsMet(spell.gesture.rightHand)) break;

                        _package = new() { succeededSpell = spell, firePoint = m_rightHand.firePoint };
                        return true;
                    }
                }
            }

            _package = null;
            return false;
        }

        public class CallbackPackage
        {
            public SpellData succeededSpell;
            public Transform firePoint;
        }
    }
}
