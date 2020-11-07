using UnityEngine;
using UnityEngine.UI;

namespace Heroes{
    public class HealthBarScript : MonoBehaviour
    {
        public Slider slider;
        public Gradient gradient;
        public Image fill;
        public ParticleSystem bloodParticle;

        private void Start()
        {
            fill.color = gradient.Evaluate(1f);
        }

        public void SetMaxHealth(float health)
        {
            slider.maxValue = health;
            slider.value = health;
        }

        public void SetHealth(float health)
        {
            slider.value = health;
            bloodParticle.Play();
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}
