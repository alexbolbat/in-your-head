using System;
using System.Collections.Generic;
using UnityEngine;
using ZSG.Behaviour;

namespace ZSG.Objects
{ 
    public class Character : MonoBehaviour
    {
        public event Action Died;

        [SerializeField]
        private float hp = 100f;
        [SerializeField]
        private List<CharacterBehaviour> behaviours;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private string dieAnimnName = "dead";
        [SerializeField]
        private List<Vulnerable> vulnerables;

        private bool isDead;


        public bool IsDead
        {
            get
            {
                return isDead;
            }
        }


        private void Start()
        {
            vulnerables.ForEach(v => v.DamageReceived += OnDamageReceived);
        }

        private void OnDestroy()
        {
            vulnerables.ForEach(v => v.DamageReceived -= OnDamageReceived);

            behaviours = null;
            animator = null;
            vulnerables = null;
        }

        private void OnDamageReceived(float hp)
        {
            this.hp -= hp;
            if (this.hp <= 0f)
            {
                Die();
            }
        }


        private void SetDeadAnimation(bool value)
        {
            if (animator != null && !string.IsNullOrEmpty(dieAnimnName))
            {
                animator.SetBool(dieAnimnName, value);
            }
        }

        private void Die()
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

            Died.Call();
        }
    }
}
