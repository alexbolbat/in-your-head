using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSG.Objects;
using ZSG.Utils;

namespace ZSG.Weapons
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField]
        private List<ColliderTriggerEnter> colliderTriggers;
        [SerializeField]
        private float postHitCooldown = 1f;
        
        private bool hitting;
        private bool isPostHitCooldown;


        private void Start()
        {
            colliderTriggers.ForEach(trigger =>
            {
                trigger.TriggerEntered += OnWeaponTriggerEntered;
            });
        }

        //animation message
        private void OnAttackStarted()
        {
            hitting = true;
        }
        //animation message
        private void OnAttackFinished()
        {
            hitting = false;
        }

        private void OnWeaponTriggerEntered(Collider other)
        {   
            if (hitting && !isPostHitCooldown)
            {
                //Debug.Log("OnWeaponTriggerEntered " + other);
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
