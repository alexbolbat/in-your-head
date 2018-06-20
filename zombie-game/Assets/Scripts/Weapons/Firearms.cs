using UnityEngine;
using ZSG.Controller;

namespace ZSG.Weapons
{
    public class Firearms : Weapon
    {
        private enum State
        {
            Idle, Fire, Reload, OutOfAmmo
        }

        [SerializeField]
        private Projectile projectile;
        [SerializeField]
        private Transform muzzle;
        [SerializeField]
        private int clipSize = 10;
        [SerializeField]
        private int rounds = 100;
        [SerializeField]
        private bool automatic;
        [SerializeField]
        private FirearmsAnimations animations;
        [SerializeField]
        private ParticleSystem fireEffect;
        [SerializeField]
        private Light lightEffect;

        private State state;
        private int roundsInClip;
        private bool shooting;

        public override void Attack()
        {
            shooting = true;
            Fire();
        }

        public override void Stop()
        {
            shooting = false;
        }


        private void Awake()
        {
            this.AssertAsset(animations);

            roundsInClip = Mathf.Min(rounds, clipSize);
        }

        private void Start()
        {
            animations.FireCompleted += OnFireAnimnCompleted;
            animations.ReloadCompleted += OnReloadAnimnCompleted;
        }

        private void OnFireAnimnCompleted()
        {
            state = State.Idle;
            if (automatic && shooting)
            { 
                Fire();
            }
        }

        private void OnReloadAnimnCompleted()
        {
            state = State.Idle;
            if (automatic && shooting)
            {
                Fire();
            }
        }

        private void Fire()
        {
            if (state != State.Idle)
            {
                return;
            }
            
            if (roundsInClip > 0)
            {
                rounds--;
                roundsInClip--;
                state = State.Fire;

                FireEffects();

                ProjectileFactory.InitProjectile(projectile, muzzle, damage);
            }
            else if (rounds > 0)
            {
                roundsInClip = Mathf.Min(rounds, clipSize);
                state = State.Reload;

                animations.Reload();
            }
            else
            {
                animations.FireEmpty();
            }
        }

        //private void 

        private void FireEffects()
        {
            animations.Fire();
            if (fireEffect != null)
            {
                fireEffect.Emit(1);
            }
            if (lightEffect != null)
            {
                lightEffect.enabled = true;
                Utils.TimerUtil.Timeout(0.1f, () => lightEffect.enabled = false);
            }
        }
    }
}
