﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField]
        private List<ColliderTriggerEnter> colliderTriggers;
        [SerializeField]
        private float postHitCooldown = 1f;
        
        private bool hitting;
        private bool isPostHitCooldown;


        public override void Attack()
        {
        }

        public override void Stop()
        {
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
            if (hitting && !isPostHitCooldown)
            {
                Vulnerable vulnerable = other.GetComponent<Vulnerable>();
                if (vulnerable != null)
                {
                    vulnerable.DealDamage(damage);
                    StartCoroutine(PostHitCooldownProcess());
                }
            }
        }

        private IEnumerator PostHitCooldownProcess()
        {
            isPostHitCooldown = true;
            yield return new WaitForSeconds(postHitCooldown);
            isPostHitCooldown = false;
        }
    }
}
