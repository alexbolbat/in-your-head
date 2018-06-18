using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField]
        private List<ColliderTriggerEnter> colliderTriggers;

        private Character target;
        private bool hitting;
        private float lastHitTime;


        public override void Attack(Character target)
        {
            this.target = target;
        }

        public override void Stop()
        {
            target = null;
        }


        private void Start()
        {
            colliderTriggers.ForEach(trigger =>
            {
                trigger.TriggerEntered += OnWeaponTriggerEntered;
            });
        }

        private void OnAttackStarted()
        {
            hitting = true;
        }

        private void OnAttackFinished()
        {
            hitting = false;
        }

        private void OnWeaponTriggerEntered(Collider other)
        {
            if (target != null && hitting)
            {
                if (lastHitTime == 0 || Time.time - lastHitTime >= fireRate)
                {
                    lastHitTime = Time.time;

                    target.DealDamage(damage);
                }
            }
        }
    }
}
