using System;
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
            gameObject.SetActive(true);
            particles.Emit(particlesCount);

            StartCoroutine(DelayedDestroy());
        }

        public override void Reset()
        {
        }


        private void Awake()
        {
            this.AssertAsset(particles);
        }


        private IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(lifetime);

            gameObject.SetActive(false);

        }
    }
}
