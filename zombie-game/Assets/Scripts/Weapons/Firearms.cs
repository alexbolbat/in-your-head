using UnityEngine;
using ZSG.Controller;
using ZSG.Utils;

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
        private float reloadTime = 1f;
        [SerializeField]
        private float fireRate = 1f;
        [SerializeField]
        private string reloadAnimnParam = "Reload";
        [SerializeField]
        private string outOfAmmoAnimnParam = "OutOfAmmo";
        [SerializeField]
        private ParticleSystem fireEffect;
        [SerializeField]
        private Light lightEffect;

        private State state;
        private int roundsInClip;
        private bool shooting;

        public override void StartAttack()
        {
            shooting = true;

            if (state == State.Idle)
            {
                base.StartAttack();

                Fire();
            }
        }

        public override void StopAttack()
        {
            base.StopAttack();

            shooting = false;
        }

        public override void AttackOnce()
        {
            if (state == State.Idle)
            { 
                base.AttackOnce();

                Fire();
            }
        }


        private void Awake()
        {
            roundsInClip = Mathf.Min(rounds, clipSize);
        }

        private void Start()
        {
        }

        private void OnFireCompleted()
        {
            if (state == State.Fire)
            { 
                state = State.Idle;
                if (shooting)
                { 
                    Fire();
                }
            }
        }

        private void OnReloadCompleted()
        {
            state = State.Idle;
            if (shooting)
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

                TimerUtil.Timeout(fireRate, OnFireCompleted);

                FireEffects();

                ProjectileFactory.InitProjectile(projectile, muzzle, damage);
            }
            else if (rounds > 0)
            {
                roundsInClip = Mathf.Min(rounds, clipSize);
                state = State.Reload;

                if (shooting)
                { 
                    base.StopAttack();
                }

                TimerUtil.Timeout(reloadTime, OnReloadCompleted);

                SetAnimationParam(reloadAnimnParam);
            }
            else
            {
                SetAnimationParam(outOfAmmoAnimnParam);
            }
        }

        //private void 

        private void FireEffects()
        {
            if (fireEffect != null)
            {
                fireEffect.Emit(1);
            }
            if (lightEffect != null)
            {
                lightEffect.enabled = true;
                TimerUtil.Timeout(0.1f, () => lightEffect.enabled = false);
            }
        }
    }
}
