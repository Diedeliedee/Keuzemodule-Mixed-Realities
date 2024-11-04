using UnityEngine;
using UnityEngine.Events;

namespace GestureSystem
{
    public class GestureRelay : MonoBehaviour
    {
        [Header("Reference:")]
        [SerializeField] private SingleHandGestureMonitor m_leftHand;
        [SerializeField] private SingleHandGestureMonitor m_rightHand;
        [Space]
        [SerializeField] private Transform m_origin;
        [SerializeField] private Transform m_head;

        public bool MonitorForCasts(SpellData[] _spells, out CallbackPackage _package)
        {
            foreach (var spell in _spells)
            {
                if (spell.gesture == null)
                {
                    Debug.LogWarning($"HOI. The gesture of {spell.name} has not been set!!!");
                    continue;
                }

                switch (spell.gesture.type)
                {
                    case GestureData.Type.PerHand:
                    {
                        if (m_leftHand.ConditionsMet(spell.gesture.leftHand))
                        {
                                _package = AssemblePackage(spell, m_leftHand.firePoint);
                                return true;
                        }
                        if (m_rightHand.ConditionsMet(spell.gesture.rightHand))
                        {
                                _package = AssemblePackage(spell, m_rightHand.firePoint);
                                return true;
                        }
                        break;
                    }

                    case GestureData.Type.BothHands:
                    {
                        if (!m_leftHand.ConditionsMet(spell.gesture.leftHand)) break;
                        if (!m_rightHand.ConditionsMet(spell.gesture.rightHand)) break;

                        _package = AssemblePackage(spell, m_rightHand.firePoint);
                        return true;
                    }
                }
            }

            _package = null;
            return false;
        }

        private CallbackPackage AssemblePackage(SpellData _spell, Transform _firePoint)
        {
            return new()
            {
                succeededSpell  = _spell,
                firePoint       = _firePoint,
                userOrigin    = m_origin,
                userHead      = m_head,
            };
        }

        public class CallbackPackage
        {
            public SpellData succeededSpell;

            public Transform firePoint;

            public Transform userOrigin;
            public Transform userHead;
        }
    }
}
