using System.Collections;
using UnityEngine;

namespace ZSG.Effects
{
    public class ParticleEmitEffect : Effect
    {
        [SerializeField]
        private ParticleSystem particles;
        [SerializeField]
        private int particlesCount = 1;
        [SerializeField]
        private float lifetime = 1f;


        public override void Show()
        {
            particles.Emit(particlesCount);

            StartCoroutine(DelayedDestroy());
        }


        private void Awake()
        {
            this.AssertAsset(particles);
        }


        private IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(lifetime);
            Destroy(gameObject);

            Destroy(gameObject);
        }
    }
}
