using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{ 
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private float hp = 100f;
        [SerializeField]
        private List<CharacterBehaviour> behaviours;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private string dieAnimnName = "dead";

        private bool isDead;

        public void DealDamage(float hp)
        {
            this.hp -= hp;
            if (this.hp <= 0f)
            {
                Die();
            }
        }

        public void Die()
        {
            if (isDead)
            {
                return;
            }
            isDead = true;
            foreach (var behaviour in behaviours)
            {
                behaviour.Die();
            }
            SetDeadAnimation(true);
        }

        private void SetDeadAnimation(bool value)
        {
            if (animator != null)
            {
                animator.SetBool(dieAnimnName, value);
            }
        }
    }
}
