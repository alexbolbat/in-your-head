using System;
using System.Collections.Generic;
using UnityEngine;
using ZSG.Behaviour;
using ZSG.Factory;
using ZSG.Utils;

namespace ZSG.Objects
{ 
    public class Character : MonoBehaviour, IReusable
    {
        public event Action Died;
        public event Action BecameUsed;

        [SerializeField]
        private float hp = 100f;
        [SerializeField]
        private List<CharacterBehaviour> behaviours;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private string dieAnimnName = "dead";
        [SerializeField]
        private float timeToDisintegrate = -1f;
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

        public T GetBehaviour<T>() where T : CharacterBehaviour
        {
            foreach (var behaviour in behaviours)
            {
                if (behaviour is T)
                {
                    return (T)behaviour;
                }
            }
            return null;
        }

        public void Reset()
        {
            behaviours.ForEach(b => b.SetActive(true));
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

            behaviours.ForEach(b => b.SetActive(false));

            SetDeadAnimation(true);

            if (timeToDisintegrate > 0)
            {
                TimerUtil.Timeout(timeToDisintegrate, () =>
                {

                });
            }

            Died.Call();
        }
    }
}
