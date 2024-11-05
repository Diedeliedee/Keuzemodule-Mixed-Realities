using UnityEngine;

namespace GestureSystem
{
    public class SpellFeedbackHandler : MonoBehaviour
    {
        [SerializeField] private int m_particleAmount = 10;
        [SerializeField] private AudioClip m_audioClip = null;

        private ParticleSystem m_particles  = null;
        private AudioSource m_audio         = null;

        private void Awake()
        {
            m_particles = GetComponent<ParticleSystem>();
            m_audio     = GetComponent<AudioSource>();
        }

        public void ProvideFeedback()
        {
            m_particles.Emit(m_particleAmount);
            m_audio.PlayOneShot(m_audioClip);
        }
    }
}